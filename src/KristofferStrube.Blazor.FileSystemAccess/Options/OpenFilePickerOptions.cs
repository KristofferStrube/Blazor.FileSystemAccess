namespace KristofferStrube.Blazor.FileSystemAccess;

public class OpenFilePickerOptions : FilePickerOptions
{
    public bool Multiple { get; set; }

    internal object Serializable()
    {
        var startIn = StartIn.CurrentValue;
        var multiple = Multiple;
        return (StartIn.IsUndefined, Multiple is false) switch
        {
            (true, true) => new { },
            (true, false) => new { multiple},
            (false, true) => new { startIn },
            (false, false) => new { startIn, multiple },
        };
    }
}
