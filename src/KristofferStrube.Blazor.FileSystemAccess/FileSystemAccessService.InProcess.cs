using KristofferStrube.Blazor.FileSystem;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <inheritdoc cref="IFileSystemAccessServiceInProcess"/>
public class FileSystemAccessServiceInProcess : FileSystemAccessService, IFileSystemAccessServiceInProcess
{
    /// <inheritdoc/>
    public FileSystemAccessServiceInProcess(IJSRuntime jSRuntime) : base(jSRuntime) { }

    /// <inheritdoc/>
    public new async Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptions? options)
    {
        IJSObjectReference helper = await helperTask.Value;
        await using IJSObjectReference jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("showOpenFilePicker", options);
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);

        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    await FileSystemFileHandleInProcess.CreateAsync(
                        jSRuntime,
                        await jSFileHandles.InvokeAsync<IJSInProcessObjectReference>("at", i),
                        new() { DisposesJSReference = true })
                )
                .ToArray()
        );
    }

    /// <inheritdoc/>
    public new async Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptions? options = null)
    {
        IJSInProcessObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("showSaveFilePicker", options);
        return await FileSystemFileHandleInProcess.CreateAsync(jSRuntime, jSFileHandle, new() { DisposesJSReference = true });
    }

    /// <inheritdoc/>
    public new async Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptions? options = null)
    {
        IJSInProcessObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("showDirectoryPicker", options);
        return await FileSystemDirectoryHandleInProcess.CreateAsync(jSRuntime, jSFileHandle, new() { DisposesJSReference = true });
    }
}
