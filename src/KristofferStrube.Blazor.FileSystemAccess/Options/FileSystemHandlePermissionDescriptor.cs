using KristofferStrube.Blazor.FileSystem;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Options used for querying and requesting permissions for a <see cref="FileSystemHandle"/> using the <see cref="FileSystemHandleExtensions.QueryPermissionAsync(FileSystemHandle, KristofferStrube.Blazor.FileSystemAccess.FileSystemHandlePermissionDescriptor?)"/> and <see cref="FileSystemHandleExtensions.RequestPermissionAsync(FileSystemHandle, KristofferStrube.Blazor.FileSystemAccess.FileSystemHandlePermissionDescriptor?)"/> methods.
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#dictdef-filesystemhandlepermissiondescriptor">See the API definition here</see>.</remarks>
public class FileSystemHandlePermissionDescriptor
{
    /// <summary>
    /// The mode of permission to query or request.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="FileSystemPermissionMode.Read"/>.
    /// </remarks>
    [JsonPropertyName("mode")]
    public FileSystemPermissionMode Mode { get; set; } = FileSystemPermissionMode.Read;
}
