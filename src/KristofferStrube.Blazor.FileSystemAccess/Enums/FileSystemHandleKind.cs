using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#enumdef-filesystemhandlekind">FileSystemHandleKind browser specs</see>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<FileSystemHandleKind>))]
public enum FileSystemHandleKind
{
    [Description("file")]
    File,
    [Description("directory")]
    Directory,
}