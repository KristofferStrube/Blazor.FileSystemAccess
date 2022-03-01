using System.Text.Json.Serialization;
using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class OpenFilePickerOptions : FilePickerOptions
{
    public bool Multiple { get; set; }

    internal new ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (!Multiple)
            res.multiple = Multiple;
        return res;
    }

}