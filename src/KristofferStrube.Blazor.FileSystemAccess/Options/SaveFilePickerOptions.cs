using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Options for opening a file using <see cref="IFileSystemAccessService.ShowSaveFilePickerAsync(SaveFilePickerOptions?)"/>
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#dictdef-savefilepickeroptions">See the API definition here</see>.</remarks>
public class SaveFilePickerOptions : FilePickerOptions
{
    /// <summary>
    /// The suggested name used for the file that is saved.
    /// </summary>
    [JsonPropertyName("suggestedName")]
    public string? SuggestedName { get; set; }
}
