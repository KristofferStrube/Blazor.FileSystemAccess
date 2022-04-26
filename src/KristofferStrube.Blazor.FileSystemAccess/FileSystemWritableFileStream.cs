using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemwritablefilestream">FileSystemWritableFileStream browser specs</see>
/// </summary>
public class FileSystemWritableFileStream
{
    protected readonly IJSObjectReference jSReference;
    protected readonly IJSInProcessObjectReference helper;

    internal FileSystemWritableFileStream(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.jSReference = jSReference;
        this.helper = helper;
    }

    public async Task WriteAsync(string data)
    {
        await jSReference.InvokeVoidAsync("write", data);
    }
    public async Task WriteAsync(Blob data)
    {
        await jSReference.InvokeVoidAsync("write", data.JSReference);
    }
    public async Task WriteAsync(BlobWriteParams data)
    {
        await helper.InvokeVoidAsync("WriteBlobWriteParams", jSReference, data, data.Data?.JSReference);
    }
    public async Task WriteAsync(StringWriteParams data)
    {
        await jSReference.InvokeVoidAsync("write", data);
    }
    public async Task SeekAsync(ulong position)
    {
        await jSReference.InvokeVoidAsync("seek", position);
    }
    public async Task TruncateAsync(ulong size)
    {
        await jSReference.InvokeVoidAsync("truncate", size);
    }
    public async Task CloseAsync()
    {
        await jSReference.InvokeVoidAsync("close");
    }
}
