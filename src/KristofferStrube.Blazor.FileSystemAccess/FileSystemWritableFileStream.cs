﻿using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemwritablefilestream">FileSystemWritableFileStream browser specs</see>
/// </summary>
public class FileSystemWritableFileStream : Stream
{
    protected readonly IJSObjectReference jSReference;
    protected readonly IJSInProcessObjectReference helper;

    public override bool CanRead => false;

    public override bool CanSeek => true;

    public override bool CanWrite => true;

    // We don't want to check the length of the file as that can change multiple times throughout the lifetime of this stream.
    public override long Length => 0;

    public override long Position { get; set; }

    internal FileSystemWritableFileStream(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.jSReference = jSReference;
        this.helper = helper;
    }

    public async Task WriteAsync(string data)
    {
        await jSReference.InvokeVoidAsync("write", data);
    }
    public async Task WriteAsync(byte[] data)
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
    public async Task WriteAsync(ByteArrayWriteParams data)
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

    public override void Flush()
    {
        helper.InvokeVoid("close", jSReference);

    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException("Reading from FileSystemWritableFileStream is not supported");
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        if (origin is not SeekOrigin.Begin)
        {
            throw new NotSupportedException("We only support seeking from the start of the file");
        }
        helper.InvokeVoid("seek", jSReference, offset);
        return offset;
    }

    public override void SetLength(long value)
    {
        helper.InvokeVoid("truncate", jSReference, value);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        helper.InvokeVoid("write", jSReference, buffer[offset..(offset+count)], offset);
    }
}
