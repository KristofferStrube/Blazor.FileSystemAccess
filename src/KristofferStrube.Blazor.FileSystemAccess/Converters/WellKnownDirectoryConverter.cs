using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess.Converters;

internal class WellKnownDirectoryConverter : JsonConverter<WellKnownDirectory>
{
    public override WellKnownDirectory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "documents" => WellKnownDirectory.Documents,
            "desktop" => WellKnownDirectory.Desktop,
            "downloads" => WellKnownDirectory.Downloads,
            "music" => WellKnownDirectory.Music,
            "pictures" => WellKnownDirectory.Pictures,
            "videos" => WellKnownDirectory.Videos,
            var value => throw new ArgumentException($"Value '{value}' was not a valid {nameof(WellKnownDirectory)}.")
        };
    }

    public override void Write(Utf8JsonWriter writer, WellKnownDirectory value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            WellKnownDirectory.Documents => "documents",
            WellKnownDirectory.Desktop => "desktop",
            WellKnownDirectory.Downloads => "downloads",
            WellKnownDirectory.Music => "music",
            WellKnownDirectory.Pictures => "pictures",
            WellKnownDirectory.Videos => "videos",
            _ => throw new ArgumentException($"Value '{value}' was not a valid {nameof(WellKnownDirectory)}.")
        });
    }
}
