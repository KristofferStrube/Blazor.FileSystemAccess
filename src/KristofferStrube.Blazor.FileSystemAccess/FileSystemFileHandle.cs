using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemFileHandle : FileSystemHandle
{
    internal FileSystemFileHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper) { }

    public async Task<File> GetFileAsync()
    {
        IJSObjectReference? jSFile = await jSReference.InvokeAsync<IJSObjectReference>("getFile");
        return new File(jSFile, helper);
    }

    public async Task<FileSystemWritableFileStream> CreateWritableAsync(FileSystemCreateWritableOptions? fileSystemCreateWritableOptions = null)
    {
        IJSObjectReference? jSFileSystemWritableFileStream = await jSReference.InvokeAsync<IJSObjectReference>("createWritable", fileSystemCreateWritableOptions);
        return new FileSystemWritableFileStream(jSFileSystemWritableFileStream);
    }
}
