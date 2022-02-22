using Microsoft.Extensions.DependencyInjection;

namespace KristofferStrube.Blazor.FileSystemAccess;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<FileSystemAccessService>();
    }
}
