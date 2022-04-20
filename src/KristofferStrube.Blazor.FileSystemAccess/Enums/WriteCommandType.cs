using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#enumdef-writecommandtype">WriteCommandType browser specs</see>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<WriteCommandType>))]
public enum WriteCommandType
{
    [Description("write")]
    Write,
    [Description("seek")]
    Seek,
    [Description("truncate")]
    Truncate,
}
