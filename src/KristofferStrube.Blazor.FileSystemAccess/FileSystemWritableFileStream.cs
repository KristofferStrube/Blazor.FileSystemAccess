using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemWritableFileStream
{
    private readonly IJSObjectReference jSReference;

    internal FileSystemWritableFileStream(IJSObjectReference jSReference)
    {
        this.jSReference = jSReference;
    }

    public async Task WriteAsync(string data)
    {
        await jSReference.InvokeVoidAsync("write", data);
    }
    public async Task CloseAsync()
    {
        await jSReference.InvokeVoidAsync("close");
    }
}
