using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class BlobWriteParams
{
    public BlobWriteParams(WriteCommandType type)
    {

    }

    [JsonPropertyName("type")]
    public WriteCommandType Type { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("size")]
    public ulong Size { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("position")]
    public ulong Position { get; set; }

    [JsonIgnore]
    public Blob Data { get; set; }
}

public class StringWriteParams
{
    public StringWriteParams(WriteCommandType type)
    {

    }

    [JsonPropertyName("type")]
    public WriteCommandType Type { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("size")]
    public ulong Size { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("position")]
    public ulong Position { get; set; }

    [JsonPropertyName("data")]
    public string Data { get; set; }
}
