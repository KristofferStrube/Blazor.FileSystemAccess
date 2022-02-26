using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemGetFileOptions
{
    [JsonPropertyName("create")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Create { get; set; }
}
