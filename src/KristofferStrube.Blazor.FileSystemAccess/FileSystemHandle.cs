using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemhandle">FileSystemHandle browser specs</see>
/// </summary>
public class FileSystemHandle : BaseJSWrapper
{
    public static FileSystemHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference)
    {
        return new FileSystemHandle(jSRuntime, jSReference);
    }

    internal FileSystemHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference) { }

    public async Task<FileSystemHandleKind> GetKindAsync()
    {
        IJSObjectReference helper = await helperTask.Value;
        return await helper.InvokeAsync<FileSystemHandleKind>("getAttribute", JSReference, "kind");
    }

    public async Task<string> GetNameAsync()
    {
        IJSObjectReference helper = await helperTask.Value;
        return await helper.InvokeAsync<string>("getAttribute", JSReference, "name");
    }

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
