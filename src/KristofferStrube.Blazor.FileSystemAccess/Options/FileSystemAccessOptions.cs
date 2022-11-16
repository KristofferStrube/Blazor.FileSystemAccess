using System.Reflection;

namespace KristofferStrube.Blazor.FileSystemAccess.Options;

public class FileSystemAccessOptions
{
    public static readonly string DefaultNamespace = Assembly.GetExecutingAssembly().GetName().Name ?? "KristofferStrube.Blazor.FileSystemAccess";
    public static readonly string DefaultPath = $"./_content/{DefaultNamespace}/{DefaultNamespace}.js";

    public string ScriptPath { get; set; } = DefaultPath;

}