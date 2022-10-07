using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSInProcessObjectReference>> helperTask;
    private readonly IJSRuntime jSRuntime;

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
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", openFilePickerOptions?.Serializable());
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemFileHandle(await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i), helper)
                )
                .ToArray()
        );
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions = null)
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", openFilePickerOptions?.Serializable());
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemFileHandle(await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i), helper)
                )
                .ToArray()
        );
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync()
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker");
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemFileHandle(await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i), helper)
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
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", saveFilePickerOptions?.Serializable());
        return new FileSystemFileHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions = null)
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", saveFilePickerOptions?.Serializable());
        return new FileSystemFileHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync()
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker");
        return new FileSystemFileHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions = null)
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showDirectoryPicker", directoryPickerOptions?.Serializable());
        return new FileSystemDirectoryHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions = null)
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showDirectoryPicker", directoryPickerOptions?.Serializable());
        return new FileSystemDirectoryHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync()
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showDirectoryPicker");
        return new FileSystemDirectoryHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> GetOriginPrivateDirectory()
    {
        IJSInProcessObjectReference helper = await helperTask.Value;
        IJSObjectReference? jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("navigator.storage.getDirectory");
        return new FileSystemDirectoryHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// Meta method for the wrapper that checks if the API is available in the current browser.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsSupported()
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
            IJSInProcessObjectReference module = await helperTask.Value;
            await module.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }
}
