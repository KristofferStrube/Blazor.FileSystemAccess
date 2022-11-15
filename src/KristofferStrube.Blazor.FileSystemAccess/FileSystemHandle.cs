using KristofferStrube.Blazor.FileSystemAccess.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemhandle">FileSystemHandle browser specs</see>
/// </summary>
public class FileSystemHandle : BaseJSWrapper
{
    internal protected delegate T CreateDelegate<T, TReference>(IJSRuntime jSRuntime, TReference jSReference, FileSystemAccessOptions options);
    internal protected static T Create<T, TReference>(IJSRuntime jSRuntime, TReference jSReference, FileSystemAccessOptions options, CreateDelegate<T, TReference> fac)
    {
        return fac(jSRuntime, jSReference, options);
    }
    internal protected static T Create<T, TReference>(IJSRuntime jSRuntime, TReference jSReference, IServiceProvider services, CreateDelegate<T, TReference> fac)
    {
        var options = services.GetService<IOptions<FileSystemAccessOptions>>();
        return fac(jSRuntime, jSReference, options?.Value ?? new());
    }
    internal protected static T Create<T, TReference>(IJSRuntime jSRuntime, TReference jSReference, CreateDelegate<T, TReference> fac)
    {
        return fac(jSRuntime, jSReference, new());
    }

    public static FileSystemHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference)
    {
        return Create(jSRuntime, jSReference,
            (r, re, o) => new FileSystemHandle(r, re, o));
    }

    public static FileSystemHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference, IServiceProvider services)
    {
        return Create(jSRuntime, jSReference, services,
            (r, re, o) => new FileSystemHandle(r, re, o));
    }

    public static FileSystemHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions options)
    {
        return new(jSRuntime, jSReference, options);
    }

    internal FileSystemHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions? options) : base(jSRuntime, jSReference, options) { }

    public async Task<FileSystemHandleKind> GetKindAsync()
    {
        IJSObjectReference helper = await helperTask.Value;
        return await helper.InvokeAsync<FileSystemHandleKind>("getAttribute", JSReference, "kind");
    }

    public async Task<string> GetNameAsync()
    {
        IJSObjectReference helper = await helperTask.Value;
        return await helper.InvokeAsync<string>("getAttribute", JSReference, "name");
    }

    public async Task<bool> IsSameEntryAsync(FileSystemHandle other)
    {
        return await JSReference.InvokeAsync<bool>("isSameEntry", other.JSReference);
    }

    public async Task<PermissionState> QueryPermissionAsync(FileSystemHandlePermissionDescriptor? description = null)
    {
        return await JSReference.InvokeAsync<PermissionState>("queryPermission", description);
    }

    public async Task<PermissionState> RequestPermissionAsync(FileSystemHandlePermissionDescriptor? description = null)
    {
        return await JSReference.InvokeAsync<PermissionState>("requestPermission", description);
    }
}
