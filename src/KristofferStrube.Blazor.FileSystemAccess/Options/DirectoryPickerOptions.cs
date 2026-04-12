using KristofferStrube.Blazor.FileSystem;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Options for opening a directory using <see cref="IFileSystemAccessService.ShowDirectoryPickerAsync(KristofferStrube.Blazor.FileSystemAccess.DirectoryPickerOptions?)"/>
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#dictdef-directorypickeroptions">See the API definition here</see>.</remarks>
public class DirectoryPickerOptions
{
    /// <summary>
    /// An id that can be used to save the users choice for future directory picks.
    /// If the id has been used previously then the directory picker will open in the last selected position.
    /// This has less priority then <see cref="StartIn"/> if it is set to a <see cref="FileSystemHandle"/>.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    /// <summary>
    /// Defines a <see cref="WellKnownDirectory"/> or <see cref="FileSystemHandle"/> that the directory picker should start in.
    /// If you specify a <see cref="WellKnownDirectory"/> then this has less priority than <see cref="Id"/> if the id had been used before.
    /// </summary>
    [JsonPropertyName("startIn")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StartInDirectory? StartIn { get; set; }

    /// <summary>
    /// The mode of permission to request for the directory that is opened.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="FileSystemPermissionMode.Read"/>.
    /// </remarks>
    [JsonPropertyName("mode")]
    public FileSystemPermissionMode Mode { get; set; } = FileSystemPermissionMode.Read;
}