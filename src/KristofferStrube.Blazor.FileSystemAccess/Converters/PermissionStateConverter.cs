using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess.Converters;

internal class PermissionStateConverter : JsonConverter<PermissionState>
{
    public override PermissionState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "granted" => PermissionState.Granted,
            "denied" => PermissionState.Denied,
            "prompt" => PermissionState.Prompt,
            var value => throw new ArgumentException($"Value '{value}' was not a valid {nameof(PermissionState)}.")
        };
    }

    public override void Write(Utf8JsonWriter writer, PermissionState value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            PermissionState.Granted => "granted",
            PermissionState.Denied => "denied",
            PermissionState.Prompt => "prompt",
            _ => throw new ArgumentException($"Value '{value}' was not a valid {nameof(PermissionState)}.")
        });
    }
}
