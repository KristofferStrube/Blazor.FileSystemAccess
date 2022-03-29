using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemwritablefilestream">FileSystemWritableFileStream browser specs</see>
/// </summary>
public class FileSystemWritableFileStream
{
    public readonly IJSObjectReference JSReference;

    internal FileSystemWritableFileStream(IJSObjectReference jSReference)
    {
        this.JSReference = jSReference;
    }

    public async Task WriteAsync(string data)
    {
        await JSReference.InvokeVoidAsync("write", data);
    }
    public async Task WriteAsync(Blob data)
    {
        await JSReference.InvokeVoidAsync("write", data.JSReference);
    }
    public async Task CloseAsync()
    {
        await JSReference.InvokeVoidAsync("close");
    }
}
