using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemHandle
{
    protected readonly IJSObjectReference jSReference;
    protected readonly IJSInProcessObjectReference helper;

    internal FileSystemHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.jSReference = jSReference;
        this.helper = helper;
    }

    public string Name => helper.Invoke<string>("getAttribute", jSReference, "name");

    public FileSystemHandleKind Kind => helper.Invoke<FileSystemHandleKind>("getAttribute", jSReference, "kind");

    public async Task<bool> IsSameEntryAsync(FileSystemHandle other)
    {
        return await jSReference.InvokeAsync<bool>("isSameEntry", other.jSReference);
    }
}
