using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSInProcessObjectReference>> moduleTask;
    private readonly IJSRuntime jsRuntime;

    public FileSystemAccessService(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSInProcessObjectReference>(
           "import", "./_content/KristofferStrube.Blazor.FileSystemAccess/KristofferStrube.Blazor.FileSystemAccess.js").AsTask());
        this.jsRuntime = jsRuntime;
    }

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

    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions? saveFilePickerOptions = null)
    {
        IJSInProcessObjectReference? helper = await moduleTask.Value;
        IJSObjectReference? jSFileHandle = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", saveFilePickerOptions?.Serializable());
        return new FileSystemFileHandle(jSFileHandle, helper);
    }

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
