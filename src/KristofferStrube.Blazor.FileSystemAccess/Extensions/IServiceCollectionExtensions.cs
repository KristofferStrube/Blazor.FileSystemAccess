using Microsoft.Extensions.DependencyInjection;

namespace KristofferStrube.Blazor.FileSystemAccess;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection)
    {
        return AddFileSystemAccessService(serviceCollection, null);
    }

    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection, Action<FileSystemAccessOptions>? configure)
    {
        ConfigureFsaOptions(serviceCollection, configure);

        return serviceCollection.AddScoped<IFileSystemAccessService, FileSystemAccessService>();
    }

    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection)
    {
        return AddFileSystemAccessServiceInProcess(serviceCollection, null);
    }

    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection, Action<FileSystemAccessOptions>? configure)
    {
        ConfigureFsaOptions(serviceCollection, configure);

        return serviceCollection
            .AddScoped<IFileSystemAccessServiceInProcess, FileSystemAccessServiceInProcess>()
            .AddScoped(sp =>
            {
                IFileSystemAccessServiceInProcess service = sp.GetRequiredService<IFileSystemAccessServiceInProcess>();
                return (IFileSystemAccessService)service;
            });
    }

    private static void ConfigureFsaOptions(IServiceCollection services, Action<FileSystemAccessOptions>? configure)
    {
        if (configure is null) { return; }

        services.Configure(configure);
        configure(FileSystemAccessOptions.DefaultInstance);
    }

}
