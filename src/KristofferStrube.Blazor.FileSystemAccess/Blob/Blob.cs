using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://w3c.github.io/FileAPI/#dfn-Blob">Blob browser specs</see>
/// </summary>
public class Blob
{
    public readonly IJSObjectReference JSReference;
    protected readonly IJSInProcessObjectReference helper;

    public static async Task<Blob> CreateAsync(IJSObjectReference jSReference, IJSRuntime jSRuntime)
    {
        IJSInProcessObjectReference helper = await jSRuntime.GetHelperAsync();
        return new Blob(jSReference, helper);
    }

    internal Blob(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.JSReference = jSReference;
        this.helper = helper;
    }

    [JsonIgnore]
    public ulong Size => helper.Invoke<ulong>("getAttribute", JSReference, "size");

    [JsonIgnore]
    public string Type => helper.Invoke<string>("getAttribute", JSReference, "type");

    public async Task<string> TextAsync()
    {
        return await JSReference.InvokeAsync<string>("text");
    }

    public async Task<byte[]> ArrayBufferAsync()
    {
        return await helper.InvokeAsync<byte[]>("arrayBuffer", JSReference);
    }
}
