using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess.Converters;

internal class FileSystemPermissionModeConverter : JsonConverter<FileSystemPermissionMode>
{
    public override FileSystemPermissionMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "read" => FileSystemPermissionMode.Read,
            "readwrite" => FileSystemPermissionMode.ReadWrite,
            var value => throw new ArgumentException($"Value '{value}' was not a valid {nameof(FileSystemPermissionMode)}.")
        };
    }

    public override void Write(Utf8JsonWriter writer, FileSystemPermissionMode value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            FileSystemPermissionMode.Read => "read",
            FileSystemPermissionMode.ReadWrite => "readwrite",
            _ => throw new ArgumentException($"Value '{value}' was not a valid {nameof(FileSystemPermissionMode)}.")
        });
    }
}
