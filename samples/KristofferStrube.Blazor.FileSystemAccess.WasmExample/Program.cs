using KristofferStrube.Blazor.FileSystemAccess;
using KristofferStrube.Blazor.FileSystemAccess.WasmExample;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFileSystemAccessServiceInProcess();

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
