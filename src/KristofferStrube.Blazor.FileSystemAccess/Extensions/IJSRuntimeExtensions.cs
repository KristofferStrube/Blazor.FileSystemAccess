using KristofferStrube.Blazor.FileSystemAccess.Options;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess.Extensions;

internal static class IJSRuntimeExtensions
{
    internal static async Task<IJSObjectReference> GetHelperAsync(this IJSRuntime jSRuntime, FileSystemAccessOptions? options)
    {
        return await jSRuntime.InvokeAsync<IJSObjectReference>(
            "import", GetScriptPath(options));
    }

    internal static async Task<IJSInProcessObjectReference> GetInProcessHelperAsync(this IJSRuntime jSRuntime, FileSystemAccessOptions? options)
    {
        return await jSRuntime.InvokeAsync<IJSInProcessObjectReference>(
            "import", GetScriptPath(options));
    }

    static string GetScriptPath(FileSystemAccessOptions? options) => options?.ScriptPath ?? FileSystemAccessOptions.DefaultPath;

}
