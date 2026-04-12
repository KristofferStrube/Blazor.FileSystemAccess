using KristofferStrube.Blazor.FileSystemAccess.Converters;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// The <see cref="WellKnownDirectory"/> enum lets a website pick one of several well-known directories.
/// The exact paths the various values of this enum map to is implementation-defined (and in some cases these might not even represent actual paths on disk).
/// </summary>
/// <remarks><see href="https://wicg.github.io/file-system-access/#enumdef-wellknowndirectory">See the API definition here</see>.</remarks>
[JsonConverter(typeof(WellKnownDirectoryConverter))]
public enum WellKnownDirectory
{
    /// <summary>
    /// Directory in which documents created by the user would typically be stored.<br />
    /// For example <c>C:\Documents and Settings\username\My Documents</c>, <c>/Users/username/Documents</c>, or <c>/home/username/Documents</c>.
    /// </summary>
    Documents,

    /// <summary>
    /// The user’s Desktop directory, if such a thing exists.<br />
    /// For example this could be <c>C:\Documents and Settings\username\Desktop</c>, <c>/Users/username/Desktop</c>, or <c>/home/username/Desktop</c>.
    /// </summary>
    Desktop,

    /// <summary>
    /// Directory where downloaded files would typically be stored.<br />
    /// For example <c>C:\Documents and Settings\username\Downloads</c>, <c>/Users/username/Downloads</c>, or <c>/home/username/Downloads</c>.
    /// </summary>
    Downloads,

    /// <summary>
    /// Directory where audio files would typically be stored.<br />
    /// For example <c>C:\Documents and Settings\username\My Documents\My Music</c>, <c>/Users/username/Music</c>, or <c>/home/username/Music</c>.
    /// </summary>
    Music,

    /// <summary>
    /// Directory where photos and other still images would typically be stored.<br />
    /// For example <c>C:\Documents and Settings\username\My Documents\My Pictures</c>, <c>/Users/username/Pictures</c>, or <c>/home/username/Pictures</c>.
    /// </summary>
    Pictures,

    /// <summary>
    /// Directory where videos/movies would typically be stored.<br />
    /// For example <c>C:\Documents and Settings\username\My Documents\My Videos</c>, <c>/Users/username/Movies</c>, or <c>/home/username/Videos</c>.
    /// </summary>
    Videos,
}
