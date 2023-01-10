[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)
[![GitHub issues](https://img.shields.io/github/issues/KristofferStrube/Blazor.FileSystemAccess)](https://github.com/KristofferStrube/Blazor.FileSystemAccess/issues)
[![GitHub forks](https://img.shields.io/github/forks/KristofferStrube/Blazor.FileSystemAccess)](https://github.com/KristofferStrube/Blazor.FileSystemAccess/network/members)
[![GitHub stars](https://img.shields.io/github/stars/KristofferStrube/Blazor.FileSystemAccess)](https://github.com/KristofferStrube/Blazor.FileSystemAccess/stargazers)

[![NuGet Downloads (official NuGet)](https://img.shields.io/nuget/dt/KristofferStrube.Blazor.FileSystemAccess?label=NuGet%20Downloads)](https://www.nuget.org/packages/KristofferStrube.Blazor.FileSystemAccess/)  

# Introduction
A Blazor wrapper for the browser API [File System Access](https://wicg.github.io/file-system-access)

The API makes it possible to read and write to your local file system from the browser both files and directories.

_Disclaimer: The API is supported on a limited set of browsers. Most noticeable not supported on Firefox, Chrome for Android, and iOS mobile browsers._

## Demo
The sample project can be demoed at https://kristofferstrube.github.io/Blazor.FileSystemAccess/

On each page you can find the corresponding code for the example in the top right corner.

On the main page you can see if the API has at least minimal support in the used browser.

# Getting Started
## Prerequisites
You need to install .NET 6.0 or newer to use the library.

[Download .NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

## Installation
You can install the package via Nuget with the Package Manager in your IDE or alternatively using the command line:
```bash
dotnet add package KristofferStrube.Blazor.FileSystemAccess
```

# Usage
The package can be used in Blazor WebAssembly and Blazor Server projects. (Note that streaming of big files is not supported in Blazor Server due to bandwidth problems.)
## Import
You also need to reference the package in order to use it in your pages. This can be done in `_Import.razor` by adding the following.
```razor
@using KristofferStrube.Blazor.FileSystemAccess
```
## Add to service collection
An easy way to make the service available in all your pages is by registering it in the `IServiceCollection` so that it can be dependency injected in the pages that need it. This is done in `Program.cs` by adding the following before you build the host and run it.
```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Other services are added.

builder.Services.AddFileSystemAccessService();

await builder.Build().RunAsync();
```
## Inject in page
Then the service can be injected in a page like so:
```razor
@inject IFileSystemAccessService FileSystemAccessService;
```
Then you can use `IFileSystemAccessService` to open one of the three dialogs available in the FileSystemAccess API like this:
```razor
<button @onclick="OpenAndReadFile">Open File Picker for Single File and Read</button>
<br />
@Text

@code {
    private string Text = "";

    private async Task OpenAndReadFile()
    {
        FileSystemFileHandle? fileHandle = null;
        try
        {
            OpenFilePickerOptionsStartInWellKnownDirectory options = new()
                {
                    Multiple = false,
                    StartIn = WellKnownDirectory.Downloads
                };
            var fileHandles = await FileSystemAccessService.ShowOpenFilePickerAsync(options);
            fileHandle = fileHandles.Single();
        }
        catch (JSException ex)
        {
            // Handle Exception or cancelation of File Access prompt
            Console.WriteLine(ex);
        }
        finally
        {
            if (fileHandle is not null)
            {
                var file = await fileHandle.GetFileAsync();
                Text = await file.TextAsync();
                StateHasChanged();
            }
        }
    }
}
```

# Issues
Feel free to open issues on the repository if you find any errors with the package or have wishes for features.

A known issue is that using Streams to stream large amount of data in Blazor Server is not supported.

# Related repositories
This project uses the *Blazor.FileSystem* package to return rich `FileSystemHandle`s both `FileSystemFileHande`s and `FileSystemDirectoryHandle`s.
- https://github.com/KristofferStrube/Blazor.FileSystem

# Related articles
This repository was build with inspiration and help from the following series of articles:

- [Wrapping JavaScript libraries in Blazor WebAssembly/WASM](https://blog.elmah.io/wrapping-javascript-libraries-in-blazor-webassembly-wasm/)
- [Call anonymous C# functions from JS in Blazor WASM](https://blog.elmah.io/call-anonymous-c-functions-from-js-in-blazor-wasm/)
- [Using JS Object References in Blazor WASM to wrap JS libraries](https://blog.elmah.io/using-js-object-references-in-blazor-wasm-to-wrap-js-libraries/)
- [Blazor WASM 404 error and fix for GitHub Pages](https://blog.elmah.io/blazor-wasm-404-error-and-fix-for-github-pages/)
- [How to fix Blazor WASM base path problems](https://blog.elmah.io/how-to-fix-blazor-wasm-base-path-problems/)
