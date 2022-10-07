using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-directorypickeroptions">DirectoryPickerOptions browser specs</see>
/// </summary>
public class DirectoryPickerOptionsStartInWellKnownDirectory : BaseDirectoryPickerOptions
{
    public new WellKnownDirectory? StartIn { get; set; }
}

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-directorypickeroptions">DirectoryPickerOptions browser specs</see>
/// </summary>
public class DirectoryPickerOptionsStartInFileSystemHandle : BaseDirectoryPickerOptions
{
    public new FileSystemHandle? StartIn { get; set; }
}

public abstract class BaseDirectoryPickerOptions
{
    public string? Id { get; set; }
    public object? StartIn { get; set; }

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
