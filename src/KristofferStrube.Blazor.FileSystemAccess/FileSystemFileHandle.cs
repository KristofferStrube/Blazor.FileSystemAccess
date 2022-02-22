using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemFileHandle
{
    private readonly IJSObjectReference jSReference;

    internal FileSystemFileHandle(IJSObjectReference jSReference)
    {
        this.jSReference = jSReference;
    }

    public async Task<File> GetFileAsync()
    {
        var jSFile = await jSReference.InvokeAsync<IJSObjectReference>("getFile");
        return new File(jSFile);
    }

    public async Task<FileSystemWritableFileStream>CreateWritableAsync(FileSystemCreateWritableOptions fileSystemCreateWritableOptions = default)
    {
        var jSFileSystemWritableFileStream = await jSReference.InvokeAsync<IJSObjectReference>("createWritable", fileSystemCreateWritableOptions);
        return new FileSystemWritableFileStream(jSFileSystemWritableFileStream);
    }
}
