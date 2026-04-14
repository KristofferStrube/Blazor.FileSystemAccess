[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)
[![GitHub issues](https://img.shields.io/github/issues/KristofferStrube/Blazor.FileSystemAccess)](https://github.com/KristofferStrube/Blazor.FileSystemAccess/issues)
[![GitHub forks](https://img.shields.io/github/forks/KristofferStrube/Blazor.FileSystemAccess)](https://github.com/KristofferStrube/Blazor.FileSystemAccess/network/members)
[![GitHub stars](https://img.shields.io/github/stars/KristofferStrube/Blazor.FileSystemAccess)](https://github.com/KristofferStrube/Blazor.FileSystemAccess/stargazers)
[![NuGet Downloads (official NuGet)](https://img.shields.io/nuget/dt/KristofferStrube.Blazor.FileSystemAccess?label=NuGet%20Downloads)](https://www.nuget.org/packages/KristofferStrube.Blazor.FileSystemAccess/)  

# Introduction
A Blazor wrapper for the browser API [File System Access](https://wicg.github.io/file-system-access)

The API makes it possible to read and write to your local file system from the browser, both files and directories.

_Disclaimer: The API is supported on a limited set of browsers. Most notably not supported on Firefox, Chrome for Android, and iOS mobile browsers._

## Demo
The sample project can be demoed at https://kristofferstrube.github.io/Blazor.FileSystemAccess/

On each page you can find the corresponding code for the example in the top right corner.

On the main page you can see if the API has at least minimal support in the browser being used.

On the [Status page](https://kristofferstrube.github.io/Blazor.FileSystemAccess/Status) you can see how much of the WebIDL specs this wrapper has covered.

# Getting Started
## Prerequisites
You need to install .NET 7.0 or newer to use the library.

[Download .NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)

## Installation
You can install the package via NuGet with the Package Manager in your IDE or alternatively using the command line:
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
            OpenFilePickerOptions options = new()
                {
                    Multiple = false,
                    StartIn = WellKnownDirectory.Downloads
                };
            var fileHandles = await FileSystemAccessService.ShowOpenFilePickerAsync(options);
            fileHandle = fileHandles.Single();
        }
        catch (JSException ex)
        {
            // Handle Exception or cancellation of File Access prompt
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

# Upgrade to version 4
Version 4 of this library made several breaking changes. To make the transition from version 3 or earlier to this version easier, I have made a small guide below for how you can upgrade. 
## File/Directory picker options
We changed the method signatures for opening the directory and file picker dialogs to make them simpler to use.

To migrate replace the following:
- `OpenFilePickerOptionsStartInWellKnownDirectory` or `OpenFilePickerOptionsStartInFileSystemHandle` with `OpenFilePickerOptions`.
- `SaveFilePickerOptionsStartInWellKnownDirectory` or `SaveFilePickerOptionsStartInFileSystemHandle` with `SaveFilePickerOptions`.
- `DirectoryPickerOptionsStartInWellKnownDirectory` or `DirectoryPickerOptionsStartInFileSystemHandle` with `DirectoryPickerOptions`.

As an example, if you had the following before:
```csharp
OpenFilePickerOptionsStartInWellKnownDirectory options = new() 
    {
        Multiple = false,
        StartIn = WellKnownDirectory.Downloads
    };
var fileHandles = await FileSystemAccessService.ShowOpenFilePickerAsync(options);
```
Update it as follows:
```csharp
OpenFilePickerOptions options = new() 
    {
        Multiple = false,
        StartIn = WellKnownDirectory.Downloads
    };
var fileHandles = await FileSystemAccessService.ShowOpenFilePickerAsync(options);
```

## Removed `FileSystemAccessOptions`
We removed the `FileSystemAccessOptions` parameter and all methods that previously accepted it as it duplicated functionality that could be achieved in other ways.

Instead of using them, you need to configure an [importmap](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/script/type/importmap) if you want to define custom paths for loading the helper modules from this library.

Blazor also has a native [ImportMap component](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/static-files?view=aspnetcore-10.0#importmap-component) that plays well with fingerprinted resources.

## Blazor.FileSystem removed `FileSystemDirectoryHandle.ValuesAsync`
The `ValuesAsync` method was removed from Blazor.FileSystem, and instead you should now use the `ValuesAsync` extension method available from Blazor.WebIDL.

This change was made to make it easier to handle memory safely.

So if you had the following before:
```csharp
var values = await directoryHandle.ValuesAsync();
for (int i = 0; i < values.Count(); i++)
{
    var value = values[i];
    string name = await value.GetNameAsync();
    FileSystemHandleKind kind = await value.GetKindAsync();
    Console.WriteLine($"'{name}' is a {kind}");
    await value.DisposeAsync();
}
```
Then you should change it to the following:
```csharp
await using var valuesIterator = await directoryHandle.ValuesAsync(disposePreviousValueWhenMovingToNextValue: true);
await foreach (FileSystemHandle value in valuesIterator)
{
    string name = await value.GetNameAsync();
    FileSystemHandleKind kind = await value.GetKindAsync();
    Console.WriteLine($"'{name}' is a {kind}");
}
```
In the above example, we pass `true` for the `disposePreviousValueWhenMovingToNextValue` parameter, which is also the default. This means that it will dispose of each handle once it iterates past it. If you need the handles after iterating, you can pass `false` for this parameter instead.

# Issues
Feel free to open issues on the repository if you find any errors with the package or have wishes for features.

A known issue is that using Streams to stream large amounts of data in Blazor Server is not supported.

# Related repositories
This project uses the *Blazor.FileSystem* package to return rich `FileSystemHandle`s both `FileSystemFileHande`s and `FileSystemDirectoryHandle`s.
- https://github.com/KristofferStrube/Blazor.FileSystem

# Related articles
This repository was built with inspiration and help from the following series of articles:

- [Wrapping JavaScript libraries in Blazor WebAssembly/WASM](https://blog.elmah.io/wrapping-javascript-libraries-in-blazor-webassembly-wasm/)
- [Call anonymous C# functions from JS in Blazor WASM](https://blog.elmah.io/call-anonymous-c-functions-from-js-in-blazor-wasm/)
- [Using JS Object References in Blazor WASM to wrap JS libraries](https://blog.elmah.io/using-js-object-references-in-blazor-wasm-to-wrap-js-libraries/)
- [Blazor WASM 404 error and fix for GitHub Pages](https://blog.elmah.io/blazor-wasm-404-error-and-fix-for-github-pages/)
- [How to fix Blazor WASM base path problems](https://blog.elmah.io/how-to-fix-blazor-wasm-base-path-problems/)
