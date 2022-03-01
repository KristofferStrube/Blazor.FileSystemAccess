using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemHandle
{
    public readonly IJSObjectReference JSReference;
    protected readonly IJSInProcessObjectReference helper;

    internal FileSystemHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.JSReference = jSReference;
        this.helper = helper;
    }

    public string Name => helper.Invoke<string>("getAttribute", JSReference, "name");

    public FileSystemHandleKind Kind => helper.Invoke<FileSystemHandleKind>("getAttribute", JSReference, "kind");

    public async Task<bool> IsSameEntryAsync(FileSystemHandle other)
    {
        return await JSReference.InvokeAsync<bool>("isSameEntry", other.JSReference);
    }
}
