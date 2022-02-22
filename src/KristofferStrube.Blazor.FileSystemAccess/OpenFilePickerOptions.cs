using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class OpenFilePickerOptions
{
    public OpenFilePickerOptions(bool multiple)
    {
        Multiple = multiple;
    }

    [JsonPropertyName("multiple")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Multiple { get; set; }
}
