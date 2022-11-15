using KristofferStrube.Blazor.FileAPI;
using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using KristofferStrube.Blazor.FileSystemAccess.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using static KristofferStrube.Blazor.FileSystemAccess.FileSystemHandle;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemfilehandle">FileSystemFileHandle browser specs</see>
/// </summary>
public class FileSystemFileHandleInProcess : FileSystemFileHandle
{
    public new IJSInProcessObjectReference JSReference;
    protected readonly IJSInProcessObjectReference inProcessHelper;

    public static async Task<FileSystemFileHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference)
    {
        return await Create(jSRuntime, jSReference, CreateAsync);
    }

    public static async Task<FileSystemFileHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, IServiceProvider services)
    {
        return await Create(jSRuntime, jSReference, services, CreateAsync);
    }

    public static async Task<FileSystemFileHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemAccessOptions? options)
    {
        IJSInProcessObjectReference inProcessHelper = await jSRuntime.GetInProcessHelperAsync(options);
        return new(jSRuntime, inProcessHelper, jSReference, options);
    }

    internal FileSystemFileHandleInProcess(IJSRuntime jSRuntime, IJSInProcessObjectReference inProcessHelper, IJSInProcessObjectReference jSReference, FileSystemAccessOptions? options) : base(jSRuntime, jSReference, options)
    {
        this.inProcessHelper = inProcessHelper;
        JSReference = jSReference;
    }

    public FileSystemHandleKind Kind => inProcessHelper.Invoke<FileSystemHandleKind>("getAttribute", JSReference, "kind");

    public string Name => inProcessHelper.Invoke<string>("getAttribute", JSReference, "name");

    public new async Task<FileInProcess> GetFileAsync()
    {
        IJSInProcessObjectReference jSFile = await JSReference.InvokeAsync<IJSInProcessObjectReference>("getFile");
        return await FileInProcess.CreateAsync(jSRuntime, jSFile);
    }

    public new async Task<FileSystemWritableFileStreamInProcess> CreateWritableAsync(FileSystemCreateWritableOptions? fileSystemCreateWritableOptions = null)
    {
        IJSInProcessObjectReference jSFileSystemWritableFileStream = await JSReference.InvokeAsync<IJSInProcessObjectReference>("createWritable", fileSystemCreateWritableOptions);
        return new FileSystemWritableFileStreamInProcess(jSRuntime, inProcessHelper, jSFileSystemWritableFileStream);
    }
}
