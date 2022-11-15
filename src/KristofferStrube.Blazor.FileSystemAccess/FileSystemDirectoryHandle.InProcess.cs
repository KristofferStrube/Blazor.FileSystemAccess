using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using KristofferStrube.Blazor.FileSystemAccess.Options;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemdirectoryhandle">FileSystemDirectoryHandle browser specs</see>
/// </summary>
public class FileSystemDirectoryHandleInProcess : FileSystemDirectoryHandle
{
    public new IJSInProcessObjectReference JSReference;
    protected readonly IJSInProcessObjectReference inProcessHelper;

    public static async Task<FileSystemDirectoryHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference)
    {
        return await Create(jSRuntime, jSReference, CreateAsync);
    }

    public static async Task<FileSystemDirectoryHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, IServiceProvider services)
    {
        return await Create(jSRuntime, jSReference, services, CreateAsync);
    }

    public static async Task<FileSystemDirectoryHandleInProcess> CreateAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemAccessOptions? options)
    {
        IJSInProcessObjectReference inProcessHelper = await jSRuntime.GetInProcessHelperAsync(options);
        return new FileSystemDirectoryHandleInProcess(jSRuntime, inProcessHelper, jSReference, options);
    }

    internal FileSystemDirectoryHandleInProcess(IJSRuntime jSRuntime, IJSInProcessObjectReference inProcessHelper, IJSInProcessObjectReference jSReference, FileSystemAccessOptions? options) : base(jSRuntime, jSReference, options)
    {
        this.inProcessHelper = inProcessHelper;
        JSReference = jSReference;
    }

    public FileSystemHandleKind Kind => inProcessHelper.Invoke<FileSystemHandleKind>("getAttribute", JSReference, "kind");

    public string Name => inProcessHelper.Invoke<string>("getAttribute", JSReference, "name");

    public new async Task<FileSystemHandleInProcess[]> ValuesAsync()
    {
        IJSObjectReference helper = await helperTask.Value;
        IJSObjectReference jSValues = await JSReference.InvokeAsync<IJSObjectReference>("values");
        IJSObjectReference jSEntries = await helper.InvokeAsync<IJSObjectReference>("arrayFrom", jSValues);
        int length = await helper.InvokeAsync<int>("size", jSEntries);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    await FileSystemHandleInProcess.CreateAsync(
                        jSRuntime,
                        await jSEntries.InvokeAsync<IJSInProcessObjectReference>("at", i),
                        this.options)
                )
                .ToArray()
        );
    }

    public new async Task<FileSystemFileHandleInProcess> GetFileHandleAsync(string name, FileSystemGetFileOptions? options = null)
    {
        IJSInProcessObjectReference jSFileSystemFileHandle = await JSReference.InvokeAsync<IJSInProcessObjectReference>("getFileHandle", name, options);
        return new FileSystemFileHandleInProcess(jSRuntime, inProcessHelper, jSFileSystemFileHandle, this.options);
    }

    public new async Task<FileSystemDirectoryHandleInProcess> GetDirectoryHandleAsync(string name, FileSystemGetDirectoryOptions? options = null)
    {
        IJSInProcessObjectReference jSFileSystemDirectoryHandle = await JSReference.InvokeAsync<IJSInProcessObjectReference>("getDirectoryHandle", name, options);
        return new FileSystemDirectoryHandleInProcess(
            jSRuntime,
            inProcessHelper,
            jSFileSystemDirectoryHandle,
            this.options);
    }
}
