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
        => await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable());

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemAccessOptions fsaOptions)
        => await InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable(), fsaOptions);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions)
        => await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable());

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemAccessOptions fsaOptions)
        => await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable(), fsaOptions);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync()
        => await InternalShowOpenFilePickerAsync(null);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(FileSystemAccessOptions fsaOptions)
        => await InternalShowOpenFilePickerAsync(null, fsaOptions);

    protected async Task<TFsFileHandle[]> InternalShowOpenFilePickerAsync(object? options)
        => await InternalShowOpenFilePickerAsync(options, FileSystemAccessOptions.DefaultInstance);
    protected async Task<TFsFileHandle[]> InternalShowOpenFilePickerAsync(object? options, FileSystemAccessOptions fsaOptions)
    {
        var helper = await helperTask.Value;
        var jSFileHandles = await jSRuntime.InvokeAsync<TObjReference>("window.showOpenFilePicker", options);
        var length = await helper.InvokeAsync<int>("size", jSFileHandles);

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
        => await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable());

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemAccessOptions fsaOptions)
        => await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable(), fsaOptions);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions)
        => await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable());

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <param name="saveFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemAccessOptions fsaOptions)
        => await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable(), fsaOptions);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync()
        => await InternalShowSaveFilePickerAsync(null);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showsavefilepicker">showSaveFilePicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(FileSystemAccessOptions options)
        => await InternalShowSaveFilePickerAsync(null, options);

    protected async Task<TFsFileHandle> InternalShowSaveFilePickerAsync(object? options)
        => await this.InternalShowSaveFilePickerAsync(options, FileSystemAccessOptions.DefaultInstance);

    protected async Task<TFsFileHandle> InternalShowSaveFilePickerAsync(object? options, FileSystemAccessOptions fsaOptions)
    {
        var jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("window.showSaveFilePicker", options);
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
        => await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable());

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemAccessOptions fasOptions)
        => await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable(), fasOptions);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions)
        => await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable());

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemAccessOptions fasOptions)
        => await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable(), fasOptions);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync()
        => await InternalShowDirectoryPickerAsync(null);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(FileSystemAccessOptions fasOptions)
        => await InternalShowDirectoryPickerAsync(null, fasOptions);

    protected async Task<TFsDirectoryHandle> InternalShowDirectoryPickerAsync(object? options)
        => await InternalShowDirectoryPickerAsync(options, FileSystemAccessOptions.DefaultInstance);

    protected async Task<TFsDirectoryHandle> InternalShowDirectoryPickerAsync(object? options, FileSystemAccessOptions fasOptions)
    {
        var jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("window.showDirectoryPicker", options);
        return await this.CreateDirectoryHandleAsync(jSRuntime, jSFileHandle, fasOptions);
    }

    #endregion

    #region GetOriginPrivateDirectoryAsync

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> GetOriginPrivateDirectoryAsync()
        => await this.GetOriginPrivateDirectoryAsync(FileSystemAccessOptions.DefaultInstance);

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#dom-storagemanager-getdirectory">getDirectory() for StorageManager browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> GetOriginPrivateDirectoryAsync(FileSystemAccessOptions fasOptions)
    {
        var jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("navigator.storage.getDirectory");
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
