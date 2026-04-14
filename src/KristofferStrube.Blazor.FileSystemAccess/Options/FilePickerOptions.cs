using KristofferStrube.Blazor.FileSystem;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Options common between <see cref="IFileSystemAccessService.ShowOpenFilePickerAsync(KristofferStrube.Blazor.FileSystemAccess.OpenFilePickerOptions?)"/>
/// and <see cref="IFileSystemAccessService.ShowSaveFilePickerAsync(KristofferStrube.Blazor.FileSystemAccess.SaveFilePickerOptions?)"/>.
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#dictdef-filepickeroptions">See the API definition here</see>.</remarks>
public abstract class FilePickerOptions
{
    /// <summary>
    /// Each entry in types specifies a single user selectable option for filtering the files displayed in the file picker.
    /// </summary>
    [JsonPropertyName("types")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FilePickerAcceptType[]? Types { get; set; }

    /// <summary>
    /// By default the file picker will also include an option to not apply any filter, letting the user select any file.
    /// Set this to <see langword="true"/> to not include this option in the file picker.
    /// </summary>
    [JsonPropertyName("excludeAcceptAllOption")]
    public bool ExcludeAcceptAllOption { get; set; } = false;

    /// <summary>
    /// An id that can be used to save the directory location used for future file picks.
    /// If the id has been used previously then the file picker will open in the last selected position.
    /// This has less priority then <see cref="StartIn"/> if it is set to a <see cref="FileSystemHandle"/>.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    /// <summary>
    /// Defines a <see cref="WellKnownDirectory"/> or <see cref="FileSystemHandle"/> that the file picker should start in.
    /// If you specify a <see cref="WellKnownDirectory"/> then this has less priority than <see cref="Id"/> if the id had been used before.
    /// </summary>
    [JsonPropertyName("startIn")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StartInDirectory? StartIn { get; set; }
}