using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemHandle
{
    internal readonly IJSObjectReference jSReference;
    private readonly IJSInProcessObjectReference helper;

    internal FileSystemHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.jSReference = jSReference;
        this.helper = helper;
    }

    public string Name => helper.Invoke<string>("getAttribute", jSReference, "name");

    public FileSystemHandleKind Kind => helper.Invoke<FileSystemHandleKind>("getAttribute", jSReference, "kind");

    public async Task<bool> IsSameEntryAsync(FileSystemHandle other) =>
        await jSReference.InvokeAsync<bool>("isSameEntry", other.jSReference);
}
