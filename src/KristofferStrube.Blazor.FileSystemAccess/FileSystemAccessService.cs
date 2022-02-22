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

    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptions openFilePickerOptions = default)
    {
        var helper = await moduleTask.Value;
        var jSFileHandles = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker", openFilePickerOptions);
        var length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemFileHandle(await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i), helper)
                )
                .ToArray()
        );
    }

    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions saveFilePickerOptions = default)
    {
        var helper = await moduleTask.Value;
        var jSFileHandle = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker", saveFilePickerOptions);
        return new FileSystemFileHandle(jSFileHandle, helper);
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
