using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-filesystemremoveoptions">FileSystemRemoveOptions browser specs</see>
/// </summary>
public class FileSystemRemoveOptions
{
    [JsonPropertyName("recursive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Recursive { get; set; }
}
