using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-filesystemhandlepermissiondescriptor">FileSystemHandlePermissionDescriptor browser specs</see>
/// </summary>
public class FileSystemHandlePermissionDescriptor
{
    [JsonPropertyName("mode")]
    public FileSystemPermissionMode Mode { get; set; } = FileSystemPermissionMode.Read;
}
