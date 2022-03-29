using System.ComponentModel;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess
{
    /// <summary>
    /// <see href="https://wicg.github.io/file-system-access/#enumdef-wellknowndirectory">WellKnownDirectory browser specs</see>
    /// </summary>
    [JsonConverter(typeof(EnumDescriptionConverter<WellKnownDirectory>))]
    public enum WellKnownDirectory
    {
        [Description("documents")]
        Documents,
        [Description("desktop")]
        Desktop,
        [Description("downloads")]
        Downloads,
        [Description("music")]
        Music,
        [Description("pictures")]
        Pictures,
        [Description("videos")]
        Videos,
    }
}
