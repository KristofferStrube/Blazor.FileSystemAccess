using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-savefilepickeroptions">SaveFilePickerOptions browser specs</see>
/// </summary>
public class SaveFilePickerOptionsStartInWellKnownDirectory : FilePickerOptionsStartInWellKnownDirectory
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

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-savefilepickeroptions">SaveFilePickerOptions browser specs</see>
/// </summary>
public class SaveFilePickerOptionsStartInFileSystemHandle : FilePickerOptionsStartInFileSystemHandle
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

