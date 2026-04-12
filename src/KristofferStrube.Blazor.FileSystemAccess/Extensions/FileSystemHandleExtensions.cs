using KristofferStrube.Blazor.FileSystem;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Extensions for querying the current permissions of a <see cref="FileSystemHandle"/> and requesting new permissions.
/// </summary>
public static class FileSystemHandleExtensions
{
    /// <summary>
    /// When <paramref name="descriptor"/> is null or <see cref="FileSystemHandlePermissionDescriptor.Mode"/> is set to <see cref="FileSystemPermissionMode.Read"/> it queries the current state of the read permission of this handle.
    /// If this returns <see cref="PermissionState.Prompt"/> the website will have to call <see cref="RequestPermissionAsync(FileSystemHandle, FileSystemHandlePermissionDescriptor?)"/> before any operations on the handle can be done.
    /// If this returns <see cref="PermissionState.Denied"/> any operations will reject.<br />
    /// Else if <see cref="FileSystemHandlePermissionDescriptor.Mode"/> is set to <see cref="FileSystemPermissionMode.ReadWrite"/> it queries the current state of the write permission of this handle.
    /// If this returns <see cref="PermissionState.Prompt"/>, attempting to modify the file or directory this handle represents will require user activation and will result in a confirmation prompt being shown to the user.
    /// However if the state of the read permission of this handle is also <see cref="PermissionState.Prompt"/> the website will need to call <see cref="RequestPermissionAsync(FileSystemHandle, FileSystemHandlePermissionDescriptor?)"/>.
    /// There is no automatic prompting for read access when attempting to read from a file or directory.
    /// </summary>
    /// <param name="handle">The handle to query permissions on.</param>
    /// <param name="descriptor">Options for what mode of permissions to query.</param>
    /// <returns>A state defining the current permission for the handle.</returns>
    public static async Task<PermissionState> QueryPermissionAsync(this FileSystemHandle handle, FileSystemHandlePermissionDescriptor? descriptor = null)
    {
        return await handle.JSReference.InvokeAsync<PermissionState>("queryPermission", descriptor);
    }

    /// <summary>
    /// If the state of the read permission of this handle is anything other than <see cref="PermissionState.Prompt"/>, this will return that state directly.<br />
    /// When <paramref name="descriptor"/> is null or <see cref="FileSystemHandlePermissionDescriptor.Mode"/> is set to <see cref="FileSystemPermissionMode.Read"/> and it is <see cref="PermissionState.Prompt"/>, user activation is needed and this will show a confirmation prompt to the user.
    /// The new read permission state is then returned, depending on the user’s response to the prompt.<br />
    /// Else if <see cref="FileSystemHandlePermissionDescriptor.Mode"/> is set to <see cref="FileSystemPermissionMode.ReadWrite"/> and the status of the read permission of this handle is <see cref="PermissionState.Denied"/> this will return that.
    /// Otherwise the state of the write permission is <see cref="PermissionState.Prompt"/> and this will show a confirmation prompt to the user.
    /// The new write permission state is then returned, depending on what the user selected.
    /// </summary>
    /// <param name="handle">The handle to query permissions on.</param>
    /// <param name="descriptor">Options for what mode of permission to request.</param>
    /// <returns></returns>
    public static async Task<PermissionState> RequestPermissionAsync(this FileSystemHandle handle, FileSystemHandlePermissionDescriptor? descriptor = null)
    {
        return await handle.JSReference.InvokeAsync<PermissionState>("requestPermission", descriptor);
    }
}