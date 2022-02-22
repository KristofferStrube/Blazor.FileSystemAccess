using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

internal class EnumDescriptionConverter<T> : JsonConverter<T> where T : IComparable, IFormattable, IConvertible
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string jsonValue = reader.GetString();

        foreach (var fi in typeToConvert.GetFields())
        {
            DescriptionAttribute description = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);

            if (description != null)
            {
                if (description.Description == jsonValue)
                {
                    return (T)fi.GetValue(null);
                }
            }
        }
        throw new JsonException($"string {jsonValue} was not found as a description in the enum {typeToConvert}");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute description = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute), false);

        writer.WriteStringValue(description.Description);
    }
}