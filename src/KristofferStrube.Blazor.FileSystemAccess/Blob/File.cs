using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://w3c.github.io/FileAPI/#dfn-file">File browser specs</see>
/// </summary>
public class File : Blob
{
    public static new async Task<File> CreateAsync(IJSObjectReference jSReference, IJSRuntime jSRuntime)
    {
        IJSInProcessObjectReference? helper = await jSRuntime.GetHelperAsync();
        return new File(jSReference, helper);
    }

    internal File(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper) { }

    public string Name => helper.Invoke<string>("getAttribute", JSReference, "name");

    public DateTime LastModified => DateTime.UnixEpoch.AddMilliseconds(helper.Invoke<long>("getAttribute", JSReference, "lastModified"));
}
