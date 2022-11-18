using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess
{
    public interface IFileSystemAccessServiceInProcess :
        IFileSystemAccessService<
            FileSystemFileHandleInProcess,
            FileSystemDirectoryHandleInProcess,
            IJSInProcessObjectReference
        >
    {
        new Task<FileSystemDirectoryHandleInProcess> GetOriginPrivateDirectoryAsync();
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync();
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions);
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions);
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync();
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions);
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions);
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync();
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions);
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions);
    }
}