using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemDirectoryHandle : FileSystemHandle
{
    internal FileSystemDirectoryHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper) { }

    public async Task<FileSystemHandle[]> ValuesAsync()
    {
        var jSValues = await jSReference.InvokeAsync<IJSObjectReference>("values");
        var jSEntries = await helper.InvokeAsync<IJSObjectReference>("arrayFrom", jSValues);
        var length = await helper.InvokeAsync<int>("size", jSEntries);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemHandle(await jSEntries.InvokeAsync<IJSObjectReference>("at", i), helper)
                )
                .ToArray()
        );
    }

    public async Task<FileSystemFileHandle> GetFileHandleAsync(string name, FileSystemGetFileOptions options = default)
    {
        var jSFileSystemFileHandle = await jSReference.InvokeAsync<IJSObjectReference>("getFileHandle", name, options);
        return new FileSystemFileHandle(jSFileSystemFileHandle, helper);
    }

    public async Task<FileSystemDirectoryHandle> GetDirectoryHandleAsync(string name, FileSystemGetDirectoryOptions options = default)
    {
        var jSFileSystemDirectoryHandle = await jSReference.InvokeAsync<IJSObjectReference>("getDirectoryHandle", name, options);
        return new FileSystemDirectoryHandle(jSFileSystemDirectoryHandle, helper);
    }
}
