using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://w3c.github.io/permissions/#dom-permissionstate">PermissionState browser specs</see>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<PermissionState>))]
public enum PermissionState
{
    [Description("granted")]
    Granted,
    [Description("denied")]
    Denied,
    [Description("prompt")]
    Prompt,
}