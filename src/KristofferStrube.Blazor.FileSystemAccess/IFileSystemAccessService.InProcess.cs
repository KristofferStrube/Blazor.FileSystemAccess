namespace KristofferStrube.Blazor.FileSystemAccess
{
    public interface IFileSystemAccessServiceInProcess : IFileSystemAccessService
    {
        new Task<FileSystemDirectoryHandleInProcess> GetOriginPrivateDirectoryAsync();
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync();
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions = null);
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions = null);
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync();
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions = null);
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions = null);
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync();
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions = null);
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions = null);
    }
}