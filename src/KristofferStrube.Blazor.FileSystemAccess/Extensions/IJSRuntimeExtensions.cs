using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess.Extensions;

internal static class IJSRuntimeExtensions
{
    internal static async Task<IJSObjectReference> GetHelperAsync(this IJSRuntime jSRuntime, FileSystemAccessOptions options)
    {
        return await GetHelperAsync<IJSObjectReference>(jSRuntime, options);
    }

    internal static async Task<IJSInProcessObjectReference> GetInProcessHelperAsync(this IJSRuntime jSRuntime, FileSystemAccessOptions options)
    {
        return await GetHelperAsync<IJSInProcessObjectReference>(jSRuntime, options);
    }

    private static async Task<T> GetHelperAsync<T>(IJSRuntime jSRuntime, FileSystemAccessOptions options)
    {
        return await jSRuntime.InvokeAsync<T>("import", GetScriptPath(options));
    }

    private static string GetScriptPath(FileSystemAccessOptions options)
    {
        return options.FullScriptPath;
    }
}
