using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess.Extensions
{
    internal static class IJSRuntimeExtensions
    {
        internal static async Task<IJSInProcessObjectReference> GetHelperAsync(this IJSRuntime jSRuntime)
        {
            return await jSRuntime.InvokeAsync<IJSInProcessObjectReference>(
                "import", "./_content/KristofferStrube.Blazor.FileSystemAccess/KristofferStrube.Blazor.FileSystemAccess.js");
        }
    }
}
