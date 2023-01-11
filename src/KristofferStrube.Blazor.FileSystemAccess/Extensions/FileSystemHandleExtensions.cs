using KristofferStrube.Blazor.FileSystem;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public static class FileSystemHandleExtensions
{
    public static async Task<PermissionState> QueryPermissionAsync(this FileSystemHandle handle, FileSystemHandlePermissionDescriptor? description = null)
    {
        return await handle.JSReference.InvokeAsync<PermissionState>("queryPermission", description);
    }

    public static async Task<PermissionState> RequestPermissionAsync(this FileSystemHandle handle, FileSystemHandlePermissionDescriptor? description = null)
    {
        return await handle.JSReference.InvokeAsync<PermissionState>("requestPermission", description);
    }
}