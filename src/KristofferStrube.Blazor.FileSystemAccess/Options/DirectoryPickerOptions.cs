using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-directorypickeroptions">DirectoryPickerOptions browser specs</see>
/// </summary>
public class DirectoryPickerOptionsStartInWellKnownDirectory
{
    public string? Id { get; set; }
    public WellKnownDirectory? StartIn { get; set; }

    internal ExpandoObject Serializable()
    {
        dynamic res = new ExpandoObject();
        if (Id != null)
        {
            res.id = Id;
        }

        if (StartIn is not null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}

public class DirectoryPickerOptionsStartInFileSystemHandle
{
    public string? Id { get; set; }
    public FileSystemHandle? StartIn { get; set; }

    internal ExpandoObject Serializable()
    {
        dynamic res = new ExpandoObject();
        if (Id != null)
        {
            res.id = Id;
        }

        if (StartIn is not null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}
