using System.Text.Json.Serialization;
using System.ComponentModel;

namespace KristofferStrube.Blazor.FileSystemAccess
{
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
