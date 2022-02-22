using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class SaveFilePickerOptions
{
    public SaveFilePickerOptions(string suggestedName)
    {
        SuggestedName = suggestedName;
    }

    [JsonPropertyName("suggestedName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string SuggestedName { get; set; }
}
