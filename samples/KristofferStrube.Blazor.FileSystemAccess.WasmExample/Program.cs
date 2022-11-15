using KristofferStrube.Blazor.FileAPI;
using KristofferStrube.Blazor.FileSystemAccess;
using KristofferStrube.Blazor.FileSystemAccess.Options;
using KristofferStrube.Blazor.FileSystemAccess.WasmExample;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFileSystemAccessServiceInProcess();
builder.Services.AddURLServiceInProcess();

// Use this configuration to use custom path
builder.Services.Configure<FileSystemAccessOptions>(opt =>
{
    // In this example, this path is copied directly to the wwwroot folder
    opt.ScriptPath = $"/content/{FileSystemAccessOptions.DefaultNamespace}/{FileSystemAccessOptions.DefaultNamespace}.js";
});

// Adding and configuring IndexedDB used for the IndexedDB sample.
builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "FileSystemAccess";
    dbStore.Version = 1;

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "FileReferences"
    });
});

await builder.Build().RunAsync();
