using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessServiceInProcess : FileSystemAccessService, IFileSystemAccessServiceInProcess
{
    protected new readonly IJSInProcessRuntime jSRuntime;

    public FileSystemAccessServiceInProcess(IJSInProcessRuntime jSRuntime) : base(jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions = null)
    {
        return await ShowOpenFilePickerPrivateAsync(openFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions = null)
    {
        return await ShowOpenFilePickerPrivateAsync(openFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public new async Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync()
    {
        return await ShowOpenFilePickerPrivateAsync(null);
    }

    private async Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerPrivateAsync(object? options)
    {
        IJSObjectReference helper = await helperTask.Value;
        IJSObjectReference jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", options);
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    await FileSystemFileHandleInProcess.CreateAsync(jSRuntime, await jSFileHandles.InvokeAsync<IJSInProcessObjectReference>("at", i))
                )
                .ToArray()
        );
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions = null)
    {
        return await ShowSaveFilePickerPrivateAsync(saveFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions = null)
    {
        return await ShowSaveFilePickerPrivateAsync(saveFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public new async Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync()
    {
        return await ShowSaveFilePickerPrivateAsync(null);
    }

    private async Task<FileSystemFileHandleInProcess> ShowSaveFilePickerPrivateAsync(object? options)
    {
        IJSInProcessObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("window.showSaveFilePicker", options);
        return await FileSystemFileHandleInProcess.CreateAsync(jSRuntime, jSFileHandle);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions = null)
    {
        return await ShowDirectoryPickerPrivateAsync(directoryPickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions = null)
    {
        return await ShowDirectoryPickerPrivateAsync(directoryPickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public new async Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync()
    {
        return await ShowDirectoryPickerPrivateAsync(null);
    }

    private async Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerPrivateAsync(object? options)
    {
        IJSInProcessObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("window.showDirectoryPicker", options);
        return await FileSystemDirectoryHandleInProcess.CreateAsync(jSRuntime, jSFileHandle);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public new async Task<FileSystemDirectoryHandleInProcess> GetOriginPrivateDirectoryAsync()
    {
        IJSInProcessObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("navigator.storage.getDirectory");
        return await FileSystemDirectoryHandleInProcess.CreateAsync(jSRuntime, jSFileHandle);
    }
}
