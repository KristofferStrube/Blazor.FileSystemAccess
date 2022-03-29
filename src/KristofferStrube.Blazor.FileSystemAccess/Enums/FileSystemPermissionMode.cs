using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#enumdef-filesystempermissionmode">FileSystemPermissionMode browser specs</see>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<FileSystemPermissionMode>))]
public enum FileSystemPermissionMode
{
    [Description("read")]
    Read,
    [Description("readwrite")]
    ReadWrite,
}