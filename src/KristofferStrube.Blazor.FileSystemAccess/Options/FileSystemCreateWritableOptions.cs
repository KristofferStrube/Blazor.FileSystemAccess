using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemCreateWritableOptions
{
    public FileSystemCreateWritableOptions(bool keepExistingData)
    {
        KeepExistingData = keepExistingData;
    }

    [JsonPropertyName("keepExistingData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool KeepExistingData { get; set; }
}
