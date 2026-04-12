using KristofferStrube.Blazor.FileSystem;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// A service that exposes methods for opening directory pickers, file-open pickers, and file-save location pickers. It also has a method <see cref="IsSupportedAsync"/> that can be used for checking for browser support for these methods.
/// </summary>
public interface IFileSystemAccessService
{
    /// <summary>
    /// Meta method for the wrapper that checks if the API is available in the current browser.
    /// </summary>
    public Task<bool> IsSupportedAsync();

    /// <summary>
    /// If <paramref name="options"/> is set to <see langword="null"/> or <see cref="DirectoryPickerOptions.Mode"/> is set to <see cref="FileSystemPermissionMode.Read"/> then it shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission.<br />
    /// Else if <see cref="DirectoryPickerOptions.Mode"/> is set to <see cref="FileSystemPermissionMode.ReadWrite"/> it shows a directory picker that lets the user select a single directory, returning a handle for the selected directory. The user agent can combine read and write permission requests on this handle into one subsequent prompt.
    /// </summary>
    /// <param name="options">Options for where to start the dialog and what permissions to request access for.</param>
    public Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptions? options = null);

    /// <summary>
    /// If <paramref name="options"/> is set to <see langword="null"/> or <see cref="OpenFilePickerOptions.Multiple"/> is set to <see langword="false"/> it shows a file picker that lets a user select a single existing file, returning a handle for the selected file.<br />
    /// Else if <see cref="OpenFilePickerOptions.Multiple"/> is set to <see langword="true"/> it shows a file picker that lets a user select multiple existing files, returning handles for the selected files.
    /// </summary>
    /// <param name="options">Options for where to start the dialog, what permissions to request access for, and whether multiple files can be selected.</param>
    public Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptions? options = null);

    /// <summary>
    /// Shows a file picker that lets a user select a single file, returning a handle for the selected file.
    /// The selected file does not have to exist already.
    /// If the selected file does not exist a new empty file is created before this method returns, otherwise the existing file is cleared before this method returned.
    /// </summary>
    /// <param name="options">Options for where to start the dialog, what permissions to request access for, an optional suggested name for the file.</param>
    /// <returns></returns>
    public Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions? options = null);
}