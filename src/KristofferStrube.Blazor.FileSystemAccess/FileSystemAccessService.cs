using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessService : IAsyncDisposable, IFileSystemAccessService
{
    protected readonly Lazy<Task<IJSObjectReference>> helperTask;
    protected readonly IJSRuntime jSRuntime;

    public FileSystemAccessService(IJSRuntime jSRuntime)
    {
        helperTask = new(() => jSRuntime.GetHelperAsync());
        this.jSRuntime = jSRuntime;
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions = null)
    {
        return await ShowOpenFilePickerPrivateAsync(openFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions = null)
    {
        return await ShowOpenFilePickerPrivateAsync(openFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync()
    {
        return await ShowOpenFilePickerPrivateAsync(null);
    }

    private async Task<FileSystemFileHandle[]> ShowOpenFilePickerPrivateAsync(object? options)
    {
        IJSObjectReference helper = await helperTask.Value;
        IJSObjectReference jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", options);
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemFileHandle(jSRuntime, await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i))
                )
                .ToArray()
        );
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions = null)
    {
        return await ShowSaveFilePickerPrivateAsync(saveFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions = null)
    {
        return await ShowSaveFilePickerPrivateAsync(saveFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync()
    {
        return await ShowSaveFilePickerPrivateAsync(null);
    }

    private async Task<FileSystemFileHandle> ShowSaveFilePickerPrivateAsync(object? options)
    {
        IJSObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", options);
        return new FileSystemFileHandle(jSRuntime, jSFileHandle);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions = null)
    {
        return await ShowDirectoryPickerPrivateAsync(directoryPickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions = null)
    {
        return await ShowDirectoryPickerPrivateAsync(directoryPickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync()
    {
        return await ShowDirectoryPickerPrivateAsync(null);
    }

    private async Task<FileSystemDirectoryHandle> ShowDirectoryPickerPrivateAsync(object? options)
    {
        IJSObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showDirectoryPicker", options);
        return new FileSystemDirectoryHandle(jSRuntime, jSFileHandle);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> GetOriginPrivateDirectoryAsync()
    {
        IJSObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("navigator.storage.getDirectory");
        return new FileSystemDirectoryHandle(jSRuntime, jSFileHandle);
    }

    /// <summary>
    /// Meta method for the wrapper that checks if the API is available in the current browser.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsSupportedAsync()
    {
        return
            await jSRuntime.InvokeAsync<bool>("window.hasOwnProperty", "showOpenFilePicker") &
            await jSRuntime.InvokeAsync<bool>("window.hasOwnProperty", "showSaveFilePicker") &
            await jSRuntime.InvokeAsync<bool>("window.hasOwnProperty", "showDirectoryPicker");
    }

    public async ValueTask DisposeAsync()
    {
        if (helperTask.IsValueCreated)
        {
            IJSObjectReference module = await helperTask.Value;
            await module.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }
}
