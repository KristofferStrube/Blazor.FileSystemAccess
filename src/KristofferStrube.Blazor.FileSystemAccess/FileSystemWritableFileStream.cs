using KristofferStrube.Blazor.FileAPI;
using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using KristofferStrube.Blazor.Streams;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemwritablefilestream">FileSystemWritableFileStream browser specs</see>
/// </summary>
public class FileSystemWritableFileStream : WritableStream
{
    public override bool CanSeek => true;

    public override long Position { get; set; }

    public static new FileSystemWritableFileStream Create(IJSRuntime jSRuntime, IJSObjectReference jSReference)
    {
        return new FileSystemWritableFileStream(jSRuntime, jSReference);
    }

    internal FileSystemWritableFileStream(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference) { }

    public override async ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        await JSReference.InvokeVoidAsync("write", buffer.ToArray());
    }

    public async Task WriteAsync(string data)
    {
        await JSReference.InvokeVoidAsync("write", data);
    }

    public async Task WriteAsync(byte[] data)
    {
        await JSReference.InvokeVoidAsync("write", data);
    }

    public async Task WriteAsync(Blob data)
    {
        await JSReference.InvokeVoidAsync("write", data.JSReference);
    }

    public async Task WriteAsync(BlobWriteParams data)
    {
        IJSObjectReference helper = await helperTask.Value;
        await helper.InvokeVoidAsync("WriteBlobWriteParams", JSReference, data, data.Data?.JSReference);
    }

    public async Task WriteAsync(StringWriteParams data)
    {
        await JSReference.InvokeVoidAsync("write", data);
    }

    public async Task WriteAsync(ByteArrayWriteParams data)
    {
        await JSReference.InvokeVoidAsync("write", data);
    }

    public async Task SeekAsync(ulong position)
    {
        Position = (long)position;
        await JSReference.InvokeVoidAsync("seek", position);
    }

    public async Task TruncateAsync(ulong size)
    {
        await JSReference.InvokeVoidAsync("truncate", size);
    }
}
