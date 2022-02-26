using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class File : Blob
{
    internal File(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper) { }

    public string Name => helper.Invoke<string>("getAttribute", jSReference, "name");

    public DateTime LastModified => DateTime.UnixEpoch.AddMilliseconds(helper.Invoke<long>("getAttribute", jSReference, "lastModified"));
}
