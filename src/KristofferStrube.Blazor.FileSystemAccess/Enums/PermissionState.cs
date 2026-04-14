using KristofferStrube.Blazor.FileSystemAccess.Converters;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Expresses permissions given.
/// </summary>
/// <remarks><see href="https://w3c.github.io/permissions/#dom-permissionstate">See the API definition here</see>.</remarks>
[JsonConverter(typeof(PermissionStateConverter))]
public enum PermissionState
{
    /// <summary>
    /// The user, or the user agent on the user's behalf, has given express permission to use a powerful feature.
    /// The caller will be able to use the feature possibly without having the user agent asking the user's permission.
    /// </summary>
    Granted,

    /// <summary>
    /// The user, or the user agent on the user's behalf, has denied access to this powerful feature.
    /// The caller won't be able to use the feature.
    /// </summary>
    Denied,

    /// <summary>
    /// The user has not given express permission to use the feature (i.e., it's the same as <see cref="Denied"/>).
    /// It also means that if a caller attempts to use the feature, the user agent will either be prompting the user for permission or access to the feature will be <see cref="Denied"/>.
    /// </summary>
    Prompt,
}