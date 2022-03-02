using AnyOfTypes;
using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class DirectoryPickerOptions
{
    public string? Id { get; set; }
    public AnyOf<WellKnownDirectory, FileSystemHandle> StartIn { get; set; }

    internal ExpandoObject Serializable()
    {
        dynamic res = new ExpandoObject();
        if (Id != null)
        {
            res.id = Id;
        }

        if (!StartIn.IsUndefined)
        {
            res.startIn = StartIn.CurrentValue;
        }

        return res;
    }
}
