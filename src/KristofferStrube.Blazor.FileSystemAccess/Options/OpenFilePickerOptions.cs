using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-openfilepickeroptions">OpenFilePickerOptions browser specs</see>
/// </summary>
public class OpenFilePickerOptionsStartInWellKnownDirectory : FilePickerOptionsStartInWellKnownDirectory
{
    public bool Multiple { get; set; }

    internal new ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (!Multiple)
        {
            res.multiple = Multiple;
        }

        return res;
    }
}

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-openfilepickeroptions">OpenFilePickerOptions browser specs</see>
/// </summary>
public class OpenFilePickerOptionsStartInInFileSystemHandle : FilePickerOptionsStartInFileSystemHandle
{
    public bool Multiple { get; set; }

    internal new ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (!Multiple)
        {
            res.multiple = Multiple;
        }

        return res;
    }
}