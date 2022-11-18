using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection)
    {
        return AddFileSystemAccessService(serviceCollection, null);
    }

    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection, Action<FileSystemAccessOptions>? configure)
    {
        if (configure is not null)
        {
            serviceCollection.Configure(configure);
        } 

        return serviceCollection.AddScoped<IFileSystemAccessService, FileSystemAccessService>();
    }

    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection)
    {
        return AddFileSystemAccessServiceInProcess(serviceCollection, null);
    }

    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection, Action<FileSystemAccessOptions>? configure)
    {

        if (configure is not null)
        {
            serviceCollection.Configure(configure);
        }

        return serviceCollection
            .AddScoped<IFileSystemAccessServiceInProcess>(
                sp => new FileSystemAccessServiceInProcess(
                    (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>(),
                    sp.GetRequiredService<IOptions<FileSystemAccessOptions>>()))
            .AddScoped<IFileSystemAccessService>(sp => sp.GetRequiredService<IFileSystemAccessServiceInProcess>());
    }
}
