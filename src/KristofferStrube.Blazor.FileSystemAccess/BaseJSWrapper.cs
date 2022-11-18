using KristofferStrube.Blazor.FileSystemAccess.Extensions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public abstract class BaseJSWrapper : IAsyncDisposable
{
    public readonly IJSObjectReference JSReference;
    protected readonly Lazy<Task<IJSObjectReference>> helperTask;
    protected readonly IJSRuntime jSRuntime;
    protected readonly FileSystemAccessOptions? options;

    /// <summary>
    /// Constructs a wrapper instance for an equivalent JS instance.
    /// </summary>
    /// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jSReference">A JS reference to an existing JS instance that should be wrapped.</param>
    internal BaseJSWrapper(IJSRuntime jSRuntime, IJSObjectReference jSReference, FileSystemAccessOptions? options)
    {
        this.options = options;
        helperTask = new(async () => await jSRuntime.GetHelperAsync(options));
        JSReference = jSReference;
        this.jSRuntime = jSRuntime;
    }

    public async ValueTask DisposeAsync()
    {
        if (helperTask.IsValueCreated)
        {
            IJSObjectReference module = await helperTask.Value;
            await module.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }
}
