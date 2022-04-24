using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-filepickeroptions">FilePickerOptions browser specs</see>
/// </summary>
public class FilePickerOptionsStartInWellKnownDirectory
{
    public FilePickerAcceptType[]? Types { get; set; }
    public bool ExcludeAcceptAllOption { get; set; }
    public string? Id { get; set; }
    public WellKnownDirectory? StartIn { get; set; }

    internal ExpandoObject Serializable()
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
public class FilePickerOptionsStartInFileSystemHandle
{
    public FilePickerAcceptType[]? Types { get; set; }
    public bool ExcludeAcceptAllOption { get; set; }
    public string? Id { get; set; }
    public FileSystemHandle? StartIn { get; set; }

    internal ExpandoObject Serializable()
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

        if (StartIn != null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}
