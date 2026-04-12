using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Options for opening a file using <see cref="IFileSystemAccessService.ShowOpenFilePickerAsync(KristofferStrube.Blazor.FileSystemAccess.OpenFilePickerOptions?)"/>
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#dictdef-openfilepickeroptions">See the API definition here</see>.</remarks>
public class OpenFilePickerOptions : FilePickerOptions
{
    /// <summary>
    /// Whether multiple files should be selectable.
    /// </summary>
    /// <remarks>
    /// Defaults to <see langword="false"/>.
    /// </remarks>
    [JsonPropertyName("multiple")]
    public bool Multiple { get; set; } = false;
}
