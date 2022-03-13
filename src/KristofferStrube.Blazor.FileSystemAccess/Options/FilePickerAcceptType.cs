using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FilePickerAcceptType
{
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    [JsonPropertyName("accept")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string[]>? Accept { get; set; }
}
