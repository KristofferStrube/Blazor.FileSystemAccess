using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-filepickeroptions">FilePickerOptions browser specs</see>
/// </summary>
public class FilePickerOptionsStartInWellKnownDirectory : BaseFilePickerOptions
{
    public WellKnownDirectory? StartIn { get; set; }

    internal override ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (StartIn != null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-filepickeroptions">FilePickerOptions browser specs</see>
/// </summary>
public class FilePickerOptionsStartInFileSystemHandle : BaseFilePickerOptions
{
    public FileSystemHandle? StartIn { get; set; }

    internal override ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (StartIn != null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}

public abstract class BaseFilePickerOptions
{
    public FilePickerAcceptType[]? Types { get; set; }
    public bool ExcludeAcceptAllOption { get; set; }
    public string? Id { get; set; }

    internal virtual ExpandoObject Serializable()
    {
        dynamic res = new ExpandoObject();
        if (Types != null)
        {
            res.types = Types;
        }

        if (!ExcludeAcceptAllOption)
        {
            res.excludeAcceptAlloption = ExcludeAcceptAllOption;
        }

        if (Id != null)
        {
            res.id = Id;
        }

        return res;
    }
}