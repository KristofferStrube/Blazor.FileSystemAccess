using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess
{

    public interface IFileSystemAccessService<TFsFileHandle, TFsDirectoryHandle, TObjReference> : IAsyncDisposable
        where TFsFileHandle : FileSystemFileHandle
        where TFsDirectoryHandle : FileSystemDirectoryHandle
        where TObjReference : IJSObjectReference
    {
        Task<TFsDirectoryHandle> GetOriginPrivateDirectoryAsync();
        Task<bool> IsSupportedAsync();

        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync();
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(FileSystemAccessOptions fasOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemAccessOptions fasOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemAccessOptions fasOptions);

        Task<TFsFileHandle[]> ShowOpenFilePickerAsync();
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(FileSystemAccessOptions fasOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemAccessOptions fasOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemAccessOptions fasOptions);

        Task<TFsFileHandle> ShowSaveFilePickerAsync();
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(FileSystemAccessOptions fasOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemAccessOptions fasOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemAccessOptions fasOptions);
    }

    public interface IFileSystemAccessService : IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>
    {
    }
}