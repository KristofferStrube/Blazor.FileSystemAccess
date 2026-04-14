using Microsoft.Extensions.DependencyInjection;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// Extensions for adding <see cref="IFileSystemAccessService"/> to the service collection.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds an <see cref="IFileSystemAccessService"/> to the service collection as a scoped service.
    /// </summary>
    /// <param name="serviceCollection">The service collection to add the service to.</param>
    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IFileSystemAccessService, FileSystemAccessService>();
    }

    /// <summary>
    /// Adds an <see cref="IFileSystemAccessServiceInProcess"/> and an <see cref="IFileSystemAccessService"/> to the service collection as scoped services.
    /// </summary>
    /// <param name="serviceCollection">The service collection to add the services to.</param>
    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IFileSystemAccessServiceInProcess, FileSystemAccessServiceInProcess>()
            .AddScoped(sp =>
            {
                IFileSystemAccessServiceInProcess service = sp.GetRequiredService<IFileSystemAccessServiceInProcess>();
                return (IFileSystemAccessService)service;
            });
    }
}
