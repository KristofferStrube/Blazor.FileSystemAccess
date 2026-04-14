using KristofferStrube.Blazor.FileSystem;
using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <inheritdoc cref="IFileSystemAccessService"/>
public class FileSystemAccessService : IFileSystemAccessService
{
    /// <summary>
    /// The <see cref="JSRuntime"/> used for making JSInterop calls.
    /// </summary>
    protected readonly IJSRuntime jSRuntime;

    /// <summary>
    /// A lazily evaluated JS module that gives access to helper methods for the File System API.
    /// </summary>
    protected readonly Lazy<Task<IJSObjectReference>> helperTask;

    /// <summary>
    /// Creates the service.
    /// </summary>
    /// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
    public FileSystemAccessService(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        helperTask = new(jSRuntime.GetHelperAsync);
    }

    /// <inheritdoc/>
    public async Task<bool> IsSupportedAsync()
    {
        return
            await jSRuntime.InvokeAsync<bool>("hasOwnProperty", "showOpenFilePicker") &
            await jSRuntime.InvokeAsync<bool>("hasOwnProperty", "showSaveFilePicker") &
            await jSRuntime.InvokeAsync<bool>("hasOwnProperty", "showDirectoryPicker");
    }

    /// <inheritdoc/>
    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptions? options = null)
    {
        IJSObjectReference helper = await helperTask.Value;
        await using IJSObjectReference jSFileHandles = await jSRuntime.InvokeAsync<IJSObjectReference>("showOpenFilePicker", options);
        int length = await helper.InvokeAsync<int>("size", jSFileHandles);

        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    await FileSystemFileHandle.CreateAsync(
                        jSRuntime,
                        await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i),
                        new() { DisposesJSReference = true })
                )
                .ToArray()
        );
    }

    /// <inheritdoc/>
    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions? options = null)
    {
        IJSObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("showSaveFilePicker", options);
        return await FileSystemFileHandle.CreateAsync(jSRuntime, jSFileHandle, new() { DisposesJSReference = true });
    }

    /// <inheritdoc/>
    public async Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptions? options = null)
    {
        IJSObjectReference jSFileHandle = await jSRuntime.InvokeAsync<IJSObjectReference>("showDirectoryPicker", options);
        return await FileSystemDirectoryHandle.CreateAsync(jSRuntime, jSFileHandle, new() { DisposesJSReference = true });
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (helperTask.IsValueCreated)
        {
            IJSObjectReference module = await helperTask.Value;
            await module.DisposeAsync();
        }
    }
}
