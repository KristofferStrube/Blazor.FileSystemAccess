using KristofferStrube.Blazor.FileSystem;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Union type representing either a <see cref="WellKnownDirectory"/> or a <see cref="FileSystemHandle"/>.
/// </summary>
[JsonConverter(typeof(UnionTypeJsonConverter<StartInDirectory>))]
public class StartInDirectory : UnionType
{
    /// <summary>
    /// Creates a <see cref="StartInDirectory"/> from a <see cref="WellKnownDirectory"/> explicitly instead of using the implicit converter.
    /// </summary>
    /// <param name="value">A <see cref="WellKnownDirectory"/>.</param>
    public StartInDirectory(WellKnownDirectory value) : base(value) { }

    /// <summary>
    /// Creates a <see cref="StartInDirectory"/> from a <see cref="FileSystemHandle"/> explicitly instead of using the implicit converter.
    /// </summary>
    /// <param name="value">A <see cref="FileSystemHandle"/>.</param>
    public StartInDirectory(FileSystemHandle value) : base(value) { }

    internal StartInDirectory(object value) : base(value)
    {
    }

    /// <summary>
    /// Creates a <see cref="StartInDirectory"/> from a <see cref="WellKnownDirectory"/>.
    /// </summary>
    /// <param name="value">A <see cref="WellKnownDirectory"/>.</param>
    public static implicit operator StartInDirectory(WellKnownDirectory value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates a <see cref="StartInDirectory"/> from a <see cref="FileSystemHandle"/>.
    /// </summary>
    /// <param name="value">A <see cref="FileSystemHandle"/>.</param>
    public static implicit operator StartInDirectory(FileSystemHandle value)
    {
        return new(value);
    }
}
