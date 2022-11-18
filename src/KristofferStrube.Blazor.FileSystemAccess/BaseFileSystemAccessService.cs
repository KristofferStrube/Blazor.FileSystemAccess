using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;
public abstract class BaseFileSystemAccessService<TFsFileHandle, TFsDirectoryHandle, TObjReference> : IFileSystemAccessService<TFsFileHandle, TFsDirectoryHandle, TObjReference>
    where TFsFileHandle : FileSystemFileHandle
    where TFsDirectoryHandle : FileSystemDirectoryHandle
    where TObjReference : IJSObjectReference
{
    protected readonly Lazy<Task<IJSObjectReference>> helperTask;
    protected readonly IJSRuntime jSRuntime;

    public BaseFileSystemAccessService(IJSRuntime jSRuntime)
    {
        helperTask = new(() => jSRuntime.GetHelperAsync(FileSystemAccessOptions.DefaultInstance));
        this.jSRuntime = jSRuntime;
    }

    #region ShowOpenFilePickerAsync

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions)
    {
        return await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemAccessOptions fsaOptions)
    {
        return await InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable(), fsaOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions)
    {
        return await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemAccessOptions fsaOptions)
    {
        return await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable(), fsaOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync()
    {
        return await InternalShowOpenFilePickerAsync(null);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(FileSystemAccessOptions fsaOptions)
    {
        return await InternalShowOpenFilePickerAsync(null, fsaOptions);
    }

    protected async Task<TFsFileHandle[]> InternalShowOpenFilePickerAsync(object? options)
    {
        return await InternalShowOpenFilePickerAsync(options, FileSystemAccessOptions.DefaultInstance);
    }

    protected async Task<TFsFileHandle[]> InternalShowOpenFilePickerAsync(object? options, FileSystemAccessOptions fsaOptions)
    {
        IJSObjectReference helper = await helperTask.Value;
        TObjReference jSFileHandles = await jSRuntime.InvokeAsync<TObjReference>("window.showOpenFilePicker", options);
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);

        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    await this.CreateFileHandleAsync(
                        jSRuntime,
                        await jSFileHandles.InvokeAsync<TObjReference>("at", i),
                        fsaOptions)
                )
                .ToArray()
        );
    }

    #endregion

    #region ShowSaveFilePickerAsync

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions)
    {
        return await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemAccessOptions fsaOptions)
    {
        return await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable(), fsaOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions)
    {
        return await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemAccessOptions fsaOptions)
    {
        return await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable(), fsaOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync()
    {
        return await InternalShowSaveFilePickerAsync(null);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(FileSystemAccessOptions options)
    {
        return await InternalShowSaveFilePickerAsync(null, options);
    }

    protected async Task<TFsFileHandle> InternalShowSaveFilePickerAsync(object? options)
    {
        return await this.InternalShowSaveFilePickerAsync(options, FileSystemAccessOptions.DefaultInstance);
    }

    protected async Task<TFsFileHandle> InternalShowSaveFilePickerAsync(object? options, FileSystemAccessOptions fsaOptions)
    {
        TObjReference jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("window.showSaveFilePicker", options);
        return await this.CreateFileHandleAsync(jSRuntime, jSFileHandle, fsaOptions);
    }

    #endregion

    #region ShowDirectoryPickerAsync

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions)
    {
        return await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable(), fasOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions)
    {
        return await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable());
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable(), fasOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync()
    {
        return await InternalShowDirectoryPickerAsync(null);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(FileSystemAccessOptions fasOptions)
    {
        return await InternalShowDirectoryPickerAsync(null, fasOptions);
    }

    protected async Task<TFsDirectoryHandle> InternalShowDirectoryPickerAsync(object? options)
    {
        return await InternalShowDirectoryPickerAsync(options, FileSystemAccessOptions.DefaultInstance);
    }

    protected async Task<TFsDirectoryHandle> InternalShowDirectoryPickerAsync(object? options, FileSystemAccessOptions fasOptions)
    {
        TObjReference jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("window.showDirectoryPicker", options);
        return await this.CreateDirectoryHandleAsync(jSRuntime, jSFileHandle, fasOptions);
    }

    #endregion

    #region GetOriginPrivateDirectoryAsync

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> GetOriginPrivateDirectoryAsync()
    {
        return await this.GetOriginPrivateDirectoryAsync(FileSystemAccessOptions.DefaultInstance);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> GetOriginPrivateDirectoryAsync(FileSystemAccessOptions fasOptions)
    {
        TObjReference jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("navigator.storage.getDirectory");
        return await CreateDirectoryHandleAsync(jSRuntime, jSFileHandle, fasOptions);
    }

    #endregion

    #region Common Handling Methods

    protected abstract Task<TFsFileHandle> CreateFileHandleAsync(IJSRuntime jSRuntime, TObjReference jSReference, FileSystemAccessOptions options);
    protected abstract Task<TFsDirectoryHandle> CreateDirectoryHandleAsync(IJSRuntime jSRuntime, TObjReference jSReference, FileSystemAccessOptions options);

    #endregion

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
