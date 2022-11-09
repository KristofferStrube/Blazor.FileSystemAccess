using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IFileSystemAccessService>();
    }
    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IFileSystemAccessServiceInProcess>(sp => new FileSystemAccessServiceInProcess((IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>()))
            .AddScoped<IFileSystemAccessService>(sp => sp.GetRequiredService<IFileSystemAccessServiceInProcess>());
    }
}
