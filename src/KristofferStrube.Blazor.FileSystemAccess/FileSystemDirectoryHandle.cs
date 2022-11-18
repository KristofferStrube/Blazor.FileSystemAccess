using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemdirectoryhandle">FileSystemDirectoryHandle browser specs</see>
/// </summary>
public class FileSystemDirectoryHandle : FileSystemHandle
{

    public static new FileSystemDirectoryHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference)
        => Create(jSRuntime, jSReference, FileSystemAccessOptions.DefaultInstance);

    public static new FileSystemDirectoryHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions options)
        => new(jSRuntime, jSReference, options);

    internal FileSystemDirectoryHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions options) : base(jSRuntime, jSReference, options) { }

    public async Task<FileSystemHandle[]> ValuesAsync()
    {
        IJSObjectReference helper = await helperTask.Value;
        IJSObjectReference jSValues = await JSReference.InvokeAsync<IJSObjectReference>("values");
        IJSObjectReference jSEntries = await helper.InvokeAsync<IJSObjectReference>("arrayFrom", jSValues);
        int length = await helper.InvokeAsync<int>("size", jSEntries);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemHandle(
                        jSRuntime,
                        await jSEntries.InvokeAsync<IJSObjectReference>("at", i),
                        this.options)
                )
                .ToArray()
        );
    }

    public async Task<FileSystemFileHandle> GetFileHandleAsync(string name, FileSystemGetFileOptions? options = null)
    {
        IJSObjectReference jSFileSystemFileHandle = await JSReference.InvokeAsync<IJSObjectReference>("getFileHandle", name, options);
        return new FileSystemFileHandle(jSRuntime, jSFileSystemFileHandle, this.options);
    }

    public async Task<FileSystemDirectoryHandle> GetDirectoryHandleAsync(string name, FileSystemGetDirectoryOptions? options = null)
    {
        IJSObjectReference jSFileSystemDirectoryHandle = await JSReference.InvokeAsync<IJSObjectReference>("getDirectoryHandle", name, options);
        return new FileSystemDirectoryHandle(jSRuntime, jSFileSystemDirectoryHandle, this.options);
    }

    public async Task RemoveEntryAsync(string name, FileSystemRemoveOptions? options = null)
    {
        await JSReference.InvokeVoidAsync("removeEntry", name, options);
    }

    public async Task<string[]?> ResolveAsync(FileSystemHandle possibleDescendant)
    {
        return await JSReference.InvokeAsync<string[]?>("resolve", possibleDescendant.JSReference);
    }
}
