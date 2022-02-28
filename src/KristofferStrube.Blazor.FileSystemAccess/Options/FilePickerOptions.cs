using AnyOfTypes;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FilePickerOptions
{
    public AnyOf<WellKnownDirectory, FileSystemHandle> StartIn { get; set; }
}
