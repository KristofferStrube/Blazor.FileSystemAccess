using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemhandle">FileSystemHandle browser specs</see>
/// </summary>
public class FileSystemHandle
{
    public readonly IJSObjectReference JSReference;
    protected readonly IJSInProcessObjectReference helper;

    public static async Task<FileSystemFileHandle> CreateAsync(IJSObjectReference jSReference, IJSRuntime jSRuntime)
    {
        IJSInProcessObjectReference helper = await jSRuntime.GetHelperAsync();
        return new FileSystemFileHandle(jSReference, helper);
    }

    internal FileSystemHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.JSReference = jSReference;
        this.helper = helper;
    }

    public string Name => helper.Invoke<string>("getAttribute", JSReference, "name");

    public FileSystemHandleKind Kind => helper.Invoke<FileSystemHandleKind>("getAttribute", JSReference, "kind");

    public async Task<bool> IsSameEntryAsync(FileSystemHandle other)
    {
        return await JSReference.InvokeAsync<bool>("isSameEntry", other.JSReference);
    }

    public async Task<PermissionState> QueryPermissionAsync(FileSystemHandlePermissionDescriptor? description = null)
    {
        return await JSReference.InvokeAsync<PermissionState>("queryPermission", description);
    }

    public async Task<PermissionState> RequestPermissionAsync(FileSystemHandlePermissionDescriptor? description = null)
    {
        return await JSReference.InvokeAsync<PermissionState>("requestPermission", description);
    }
}
