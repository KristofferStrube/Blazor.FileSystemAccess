using KristofferStrube.Blazor.FileSystem;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <inheritdoc cref="IFileSystemAccessService" path="/summary"/>. This service returns in-process variants for the various methods that return <see cref="FileSystemHandle"/>s.
/// </summary>
public interface IFileSystemAccessServiceInProcess : IFileSystemAccessService
{
    /// <inheritdoc cref="IFileSystemAccessService.ShowDirectoryPickerAsync(DirectoryPickerOptions?)"/>
    public new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptions? options = null);

    /// <inheritdoc cref="IFileSystemAccessService.ShowOpenFilePickerAsync(OpenFilePickerOptions?)"/>
    public new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptions? options = null);

    /// <inheritdoc cref="IFileSystemAccessService.ShowSaveFilePickerAsync(SaveFilePickerOptions?)"/>
    public new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptions? options = null);
}