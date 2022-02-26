using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemGetDirectoryOptions
{
    [JsonPropertyName("create")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Create { get; set; }
}
