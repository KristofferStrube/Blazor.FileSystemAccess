using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://w3c.github.io/FileAPI/#dfn-Blob">Blob browser specs</see>
/// </summary>
public class Blob
{
    public readonly IJSObjectReference JSReference;
    protected readonly IJSInProcessObjectReference helper;

    public Blob(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.JSReference = jSReference;
        this.helper = helper;
    }

    public ulong Size => helper.Invoke<ulong>("getAttribute", JSReference, "size");

    public string Type => helper.Invoke<string>("getAttribute", JSReference, "type");

    public async Task<string> TextAsync()
    {
        return await JSReference.InvokeAsync<string>("text");
    }
}
