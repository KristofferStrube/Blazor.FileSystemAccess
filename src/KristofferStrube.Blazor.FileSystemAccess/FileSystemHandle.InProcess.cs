using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemfilehandle">FileSystemFileHandle browser specs</see>
/// </summary>
public class FileSystemHandleInProcess : FileSystemFileHandle
{
    public new IJSInProcessObjectReference JSReference;
    protected readonly IJSInProcessObjectReference inProcessHelper;

    [Obsolete("Use CreateFileSystemHandleInProcessAsync from IFileSystemAccessService instead")]
    public static async Task<FileSystemHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference)
        => await CreateAsync(jSRuntime, jSReference, null);

    internal static async Task<FileSystemHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemAccessOptions? options)
    {
        IJSInProcessObjectReference inProcessHelper = await jSRuntime.GetInProcessHelperAsync(options);
        return new FileSystemHandleInProcess(jSRuntime, inProcessHelper, jSReference, options);
    }

    internal FileSystemHandleInProcess(IJSRuntime jSRuntime, IJSInProcessObjectReference inProcessHelper, IJSInProcessObjectReference jSReference, FileSystemAccessOptions? options) : base(jSRuntime, jSReference, options)
    {
        this.inProcessHelper = inProcessHelper;
        JSReference = jSReference;
    }

    public FileSystemHandleKind Kind => inProcessHelper.Invoke<FileSystemHandleKind>("getAttribute", JSReference, "kind");

    public string Name => inProcessHelper.Invoke<string>("getAttribute", JSReference, "name");
}
