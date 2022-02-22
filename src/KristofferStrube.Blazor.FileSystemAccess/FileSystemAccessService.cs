using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    private readonly IJSRuntime jsRuntime;

    public FileSystemAccessService(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
           "import", "./_content/KristofferStrube.Blazor.FileSystemAccess/KristofferStrube.Blazor.FileSystemAccess.js").AsTask());
        this.jsRuntime = jsRuntime;
    }

    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptions openFilePickerOptions = default)
    {
        var module = await moduleTask.Value;
        var jSFileHandles = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", openFilePickerOptions);
        var length = await module.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemFileHandle(await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i))
                )
                .ToArray()
        );
    }

    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions saveFilePickerOptions = default)
    {
        var jSFileHandle = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", saveFilePickerOptions);
        return new FileSystemFileHandle(jSFileHandle);
    }


    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
