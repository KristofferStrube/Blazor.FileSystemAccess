using KristofferStrube.Blazor.FileAPI;
using KristofferStrube.Blazor.FileSystemAccess;
using TG.Blazor.IndexedDB;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddFileSystemAccessService();
builder.Services.AddURLService();

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

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
