using KristofferStrube.Blazor.FileSystem;
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
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable(), fsOptions);
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
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await this.InternalShowOpenFilePickerAsync(openFilePickerOptions?.Serializable(), fsOptions);
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
    public async Task<TFsFileHandle[]> ShowOpenFilePickerAsync(FileSystemOptions fsOptions)
    {
        return await InternalShowOpenFilePickerAsync(null, fsOptions);
    }

    protected async Task<TFsFileHandle[]> InternalShowOpenFilePickerAsync(object? options)
    {
        return await InternalShowOpenFilePickerAsync(options, new FileSystemOptions());
    }

    protected async Task<TFsFileHandle[]> InternalShowOpenFilePickerAsync(object? options, FileSystemOptions fsOptions)
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
                        fsOptions)
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
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable(), fsOptions);
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
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await InternalShowSaveFilePickerAsync(saveFilePickerOptions?.Serializable(), fsOptions);
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
    public async Task<TFsFileHandle> ShowSaveFilePickerAsync(FileSystemOptions options)
    {
        return await InternalShowSaveFilePickerAsync(null, options);
    }

    protected async Task<TFsFileHandle> InternalShowSaveFilePickerAsync(object? options)
    {
        return await this.InternalShowSaveFilePickerAsync(options, new FileSystemOptions());
    }

    protected async Task<TFsFileHandle> InternalShowSaveFilePickerAsync(object? options, FileSystemOptions fsOptions)
    {
        TObjReference jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("window.showSaveFilePicker", options);
        return await this.CreateFileHandleAsync(jSRuntime, jSFileHandle, fsOptions);
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
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemOptions fsOptions)
    {
        return await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable(), fsOptions);
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
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemOptions fsOptions)
    {
        return await InternalShowDirectoryPickerAsync(directoryPickerOptions?.Serializable(), fsOptions);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync()
    {
        return await InternalShowDirectoryPickerAsync(null);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="fsOptions"></param>
    /// <returns></returns>
    public async Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(FileSystemOptions fsOptions)
    {
        return await InternalShowDirectoryPickerAsync(null, fsOptions);
    }

    protected async Task<TFsDirectoryHandle> InternalShowDirectoryPickerAsync(object? options)
    {
        return await InternalShowDirectoryPickerAsync(options, new FileSystemOptions());
    }

    protected async Task<TFsDirectoryHandle> InternalShowDirectoryPickerAsync(object? options, FileSystemOptions fsOptions)
    {
        TObjReference jSFileHandle = await jSRuntime.InvokeAsync<TObjReference>("window.showDirectoryPicker", options);
        return await this.CreateDirectoryHandleAsync(jSRuntime, jSFileHandle, fsOptions);
    }

    #endregion

    #region Common Handling Methods

    protected abstract Task<TFsFileHandle> CreateFileHandleAsync(IJSRuntime jSRuntime, TObjReference jSReference, FileSystemOptions options);
    protected abstract Task<TFsDirectoryHandle> CreateDirectoryHandleAsync(IJSRuntime jSRuntime, TObjReference jSReference, FileSystemOptions options);

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
