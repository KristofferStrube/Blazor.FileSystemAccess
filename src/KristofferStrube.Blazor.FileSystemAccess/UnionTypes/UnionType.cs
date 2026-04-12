using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// A common Union Type class.
/// </summary>
[JsonConverter(typeof(UnionTypeJsonConverter<UnionType>))]
public class UnionType
{
    /// <summary>
    /// Creates a Union Type class from a value.
    /// </summary>
    /// <param name="value"></param>
    protected UnionType(object value)
    {
        Value = value;
    }

    /// <summary>
    /// The value of the Union Type.
    /// </summary>
    public object Value { get; }
}
