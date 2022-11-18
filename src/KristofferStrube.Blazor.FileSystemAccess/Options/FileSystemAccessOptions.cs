using System.Reflection;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessOptions
{
    public const string DefaultBasePath = "./_content/";
    public static readonly string DefaultNamespace = Assembly.GetExecutingAssembly().GetName().Name ?? "KristofferStrube.Blazor.FileSystemAccess";
    public static readonly string DefaultScriptPath = $"{DefaultNamespace}/{DefaultNamespace}.js";

    public string BasePath { get; set; } = DefaultBasePath;
    public string ScriptPath { get; set; } = DefaultScriptPath;

    public string FullScriptPath => Path.Combine(this.BasePath, this.ScriptPath);

    internal static FileSystemAccessOptions DefaultInstance = new();

}