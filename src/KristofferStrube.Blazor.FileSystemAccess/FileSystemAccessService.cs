using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSInProcessObjectReference>> moduleTask;
    private readonly IJSRuntime jsRuntime;

    /// <summary>
    /// Helper object that can access helper JS functions needed in the library
    /// </summary>
    /// <returns></returns>
    public async Task<IJSInProcessObjectReference> HelperAsync()
    {
        return await moduleTask.Value;
    }

    public FileSystemAccessService(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSInProcessObjectReference>(
           "import", "./_content/KristofferStrube.Blazor.FileSystemAccess/KristofferStrube.Blazor.FileSystemAccess.js").AsTask());
        this.jsRuntime = jsRuntime;
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showopenfilepicker">showOpenFilePicker() browser specs</see>
    /// </summary>
    /// <param name="openFilePickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptions? openFilePickerOptions = null)
    {
        IJSInProcessObjectReference? helper = await moduleTask.Value;
        IJSObjectReference? jSFileHandles = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", openFilePickerOptions?.Serializable());
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
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions? saveFilePickerOptions = null)
    {
        IJSInProcessObjectReference? helper = await moduleTask.Value;
        IJSObjectReference? jSFileHandle = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", saveFilePickerOptions?.Serializable());
        return new FileSystemFileHandle(jSFileHandle, helper);
    }

    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#api-showdirectorypicker">showDirectoryPicker() browser specs</see>
    /// </summary>
    /// <param name="directoryPickerOptions"></param>
    /// <returns></returns>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptions? directoryPickerOptions = null)
    {
        IJSInProcessObjectReference? helper = await moduleTask.Value;
        IJSObjectReference? jSFileHandle = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showDirectoryPicker", directoryPickerOptions?.Serializable());
        return new FileSystemDirectoryHandle(jSFileHandle, helper);
    }


    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            IJSInProcessObjectReference? module = await moduleTask.Value;
            await module.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }
}
