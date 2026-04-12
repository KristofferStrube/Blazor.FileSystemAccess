using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Text.Json.JsonSerializer;

namespace KristofferStrube.Blazor.FileSystemAccess;

internal class UnionTypeJsonConverter<T> : JsonConverter<T> where T : UnionType
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new InvalidOperationException("Can't deserialize UnionTypes from the Blazor.MediaCaptureStreams library.");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value.Value is not null)
        {
            writer.WriteRawValue(Serialize(value.Value, value.Value.GetType(), options));
        }
    }
}
