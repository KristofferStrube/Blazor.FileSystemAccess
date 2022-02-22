using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class File
{
    private readonly IJSObjectReference jSReference;

    internal File(IJSObjectReference jSReference)
    {
        this.jSReference = jSReference;
    }

    public async Task<string> TextAsync()
    {
        return await jSReference.InvokeAsync<string>("text");
    }
}
