using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

[JsonConverter(typeof(EnumDescriptionConverter<FileSystemHandleKind>))]
public enum FileSystemHandleKind
{
    [Description("file")]
    File,
    [Description("directory")]
    Directory,
}