using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class SaveFilePickerOptions : FilePickerOptions
{
    public string? SuggestedName { get; set; }

    internal new ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (SuggestedName != null)
        {
            res.suggestedName = SuggestedName;
        }

        return res;
    }
}
