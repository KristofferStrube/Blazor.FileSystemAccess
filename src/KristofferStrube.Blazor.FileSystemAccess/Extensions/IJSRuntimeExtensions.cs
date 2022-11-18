using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess.Extensions;

internal static class IJSRuntimeExtensions
{
    internal static async Task<IJSObjectReference> GetHelperAsync(this IJSRuntime jSRuntime, FileSystemAccessOptions options)
        => await GetHelperAsync<IJSObjectReference>(jSRuntime, options);

    internal static async Task<IJSInProcessObjectReference> GetInProcessHelperAsync(this IJSRuntime jSRuntime, FileSystemAccessOptions options) =>
        await GetHelperAsync<IJSInProcessObjectReference>(jSRuntime, options);

    static async Task<T> GetHelperAsync<T>(IJSRuntime jSRuntime, FileSystemAccessOptions options) =>
        await jSRuntime.InvokeAsync<T>("import", GetScriptPath(options));

    static string GetScriptPath(FileSystemAccessOptions options) => options.FullScriptPath;
}
