using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemhandle">FileSystemHandle browser specs</see>
/// </summary>
public class FileSystemHandle : BaseJSWrapper
{

    [Obsolete("Use CreateFileSystemHandle from IFileSystemAccessService instead.")]
    public static FileSystemHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference)
        => Create(jSRuntime, jSReference, null);

    internal static FileSystemHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions? options)
        => new(jSRuntime, jSReference, options);

    internal FileSystemHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions? options) : base(jSRuntime, jSReference, options) { }

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
