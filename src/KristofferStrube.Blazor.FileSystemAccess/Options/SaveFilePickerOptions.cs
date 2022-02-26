namespace KristofferStrube.Blazor.FileSystemAccess;

public class SaveFilePickerOptions : FilePickerOptions
{
    public string SuggestedName { get; set; }

    internal object Serializable()
    {
        var startIn = StartIn.CurrentValue;
        var suggestedName = SuggestedName;
        return (StartIn.IsUndefined, SuggestedName is null) switch {
            (true, true) => new {},
            (true, false) => new { suggestedName },
            (false, true) => new { startIn },
            (false, false) => new { startIn, suggestedName },
        };
    }
}
