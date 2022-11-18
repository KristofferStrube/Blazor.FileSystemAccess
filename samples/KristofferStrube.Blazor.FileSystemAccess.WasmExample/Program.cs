using KristofferStrube.Blazor.FileAPI;
using KristofferStrube.Blazor.FileSystemAccess;
using KristofferStrube.Blazor.FileSystemAccess.WasmExample;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configure with custom script path
builder.Services.AddFileSystemAccessServiceInProcess(options =>
{
    // The file at this path in this example is manually copied to wwwroot folder
    // options.BasePath = "content/";
    // options.ScriptPath = $"custom-path/{FileSystemAccessOptions.DefaultNamespace}.js";
});

builder.Services.AddURLServiceInProcess();

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
