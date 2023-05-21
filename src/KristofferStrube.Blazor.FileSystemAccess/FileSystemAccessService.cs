using KristofferStrube.Blazor.FileSystem;
using KristofferStrube.Blazor.WebIDL;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessService :
    BaseFileSystemAccessService<
        FileSystemFileHandle,
        FileSystemDirectoryHandle,
        IJSObjectReference>,
    IFileSystemAccessService
{
    public FileSystemAccessService(IErrorHandlingJSRuntime errorHandlingJSRuntime, IJSRuntime jSRuntime) : base(errorHandlingJSRuntime, jSRuntime)
    {
    }

    protected override Task<FileSystemDirectoryHandle> CreateDirectoryHandleAsync(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemOptions options)
    {
        return Task.FromResult(FileSystemDirectoryHandle.Create(jSRuntime, jSReference, options));
    }

    protected override Task<FileSystemFileHandle> CreateFileHandleAsync(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemOptions options)
    {
        return Task.FromResult(FileSystemFileHandle.Create(jSRuntime, jSReference, options));
    }
}
