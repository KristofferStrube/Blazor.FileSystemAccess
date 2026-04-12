using KristofferStrube.Blazor.FileSystemAccess.Converters;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// The permission modes used when accessing a file system handle.
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#enumdef-filesystempermissionmode">See the API definition here</see>.</remarks>
[JsonConverter(typeof(FileSystemPermissionModeConverter))]
public enum FileSystemPermissionMode
{
    /// <summary>
    /// Read access.
    /// </summary>
    Read,

    /// <summary>
    /// Read and write access.
    /// </summary>
    ReadWrite,
}