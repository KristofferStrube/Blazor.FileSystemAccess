using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemdirectoryhandle">FileSystemDirectoryHandle browser specs</see>
/// </summary>
public class FileSystemDirectoryHandle : FileSystemHandle
{
    internal FileSystemDirectoryHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper) { }

    public async Task<FileSystemHandle[]> ValuesAsync()
    {
        IJSObjectReference? jSValues = await JSReference.InvokeAsync<IJSObjectReference>("values");
        IJSObjectReference? jSEntries = await helper.InvokeAsync<IJSObjectReference>("arrayFrom", jSValues);
        int length = await helper.InvokeAsync<int>("size", jSEntries);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemHandle(await jSEntries.InvokeAsync<IJSObjectReference>("at", i), helper)
                )
                .ToArray()
        );
    }

    public async Task<FileSystemFileHandle> GetFileHandleAsync(string name, FileSystemGetFileOptions? options = null)
    {
        IJSObjectReference? jSFileSystemFileHandle = await JSReference.InvokeAsync<IJSObjectReference>("getFileHandle", name, options);
        return new FileSystemFileHandle(jSFileSystemFileHandle, helper);
    }

    public async Task<FileSystemDirectoryHandle> GetDirectoryHandleAsync(string name, FileSystemGetDirectoryOptions? options = null)
    {
        IJSObjectReference? jSFileSystemDirectoryHandle = await JSReference.InvokeAsync<IJSObjectReference>("getDirectoryHandle", name, options);
        return new FileSystemDirectoryHandle(jSFileSystemDirectoryHandle, helper);
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
