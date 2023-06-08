using KristofferStrube.Blazor.FileSystem;
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
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync();
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions);
        new Task<FileSystemDirectoryHandleInProcess> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions);

        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync()" path="/summary"/>
        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync()" path="/exception"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandleInProcess"/>.</returns>
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync();

        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle?)" path="/summary"/>
        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory?)" path="/param"/>
        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle?)" path="/exception"/>
        /// <returns>A new array of <see cref="FileSystemFileHandleInProcess"/>.</returns>
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions);

        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory?)" path="/summary"/>
        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory?)" path="/param"/>
        /// <inheritdoc cref="IFileSystemAccessService{TFsFileHandle, TFsDirectoryHandle, TObjReference}.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory?)" path="/exception"/>
        /// <returns>A new array of <see cref="FileSystemFileHandleInProcess"/>.</returns>
        new Task<FileSystemFileHandleInProcess[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions);
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync();
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions);
        new Task<FileSystemFileHandleInProcess> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions);
    }
}