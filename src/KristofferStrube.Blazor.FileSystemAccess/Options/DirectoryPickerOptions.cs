using AnyOfTypes;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class DirectoryPickerOptions
{
    public AnyOf<WellKnownDirectory, FileSystemHandle> StartIn { get; set; }
    public string Id { get; set; }

    internal object Serializable()
    {
        var startIn = StartIn.CurrentValue;
        var id = Id;
        return (StartIn.IsUndefined, Id is null) switch
        {
            (true, true) => new { },
            (true, false) => new { id },
            (false, true) => new { startIn },
            (false, false) => new { startIn, id },
        };
    }
}
