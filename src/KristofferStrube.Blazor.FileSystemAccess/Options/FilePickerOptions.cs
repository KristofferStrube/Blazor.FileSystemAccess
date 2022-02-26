using AnyOfTypes;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FilePickerOptions
{
    public AnyOf<WellKnownDirectory, FileSystemHandle> StartIn { get; set; }
}
