using KristofferStrube.Blazor.FileSystemAccess.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddFileSystemAccessService(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IFileSystemAccessService, FileSystemAccessService>();
    }
    public static IServiceCollection AddFileSystemAccessServiceInProcess(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IFileSystemAccessServiceInProcess>(sp => new FileSystemAccessServiceInProcess(
                    (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>(),
                    sp.GetService<IOptions<FileSystemAccessOptions>>()))
            .AddScoped<IFileSystemAccessService>(sp => sp.GetRequiredService<IFileSystemAccessServiceInProcess>());
    }

}
