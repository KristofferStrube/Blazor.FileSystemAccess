using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// A single user selectable option for filtering the files displayed in the file picker.
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#dictdef-filepickeraccepttype">See the API definition here</see>.</remarks>
public class FilePickerAcceptType
{
    /// <summary>
    /// An optional description. If no description is provided one will be generated.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; } = "";

    /// <summary>
    /// A number of MIME types and extensions (specified as a mapping of MIME type to a list of extensions).
    /// Extensions have to be strings that start with a "." and only contain valid suffix code points.
    /// Additionally extensions are limited to a length of 16 code points.<br />
    /// In addition to complete MIME types, <c>"*"</c> can be used as the subtype of a MIME type to match for example all image formats with <c>"image/*"</c>.
    /// Websites should always provide both MIME types and file extensions for each option.
    /// On platforms that only use file extensions to describe file types user agents can match on the extensions, while on platforms that don’t use extensions, user agents can match on MIME type.
    /// By default the file picker will also include an option to not apply any filter, letting the user select any file. Set <see cref="FilePickerOptions.ExcludeAcceptAllOption"/> to <see langword="true"/> to not include this option in the file picker.
    /// </summary>
    [JsonPropertyName("accept")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string[]>? Accept { get; set; }
}
