using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class BlobWriteParams : BaseWriteParams
{
    public BlobWriteParams(WriteCommandType type)
    {
        Type = type;
    }

    [JsonIgnore]
    public new Blob? Data { get; set; }
}

public class StringWriteParams : BaseWriteParams
{
    public StringWriteParams(WriteCommandType type)
    {
        Type = type;
    }

    [JsonPropertyName("data")]
    public new string? Data { get; set; }
}

public class ByteArrayWriteParams : BaseWriteParams
{
    public ByteArrayWriteParams(WriteCommandType type)
    {
        Type = type;
    }

    [JsonPropertyName("data")]
    public new byte[]? Data { get; set; }
}

public abstract class BaseWriteParams
{
    [JsonPropertyName("type")]
    public WriteCommandType Type { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("size")]
    public ulong Size { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("position")]
    public ulong Position { get; set; }

    [JsonPropertyName("data")]
    public object? Data { get; set; }
}