using KristofferStrube.Blazor.FileSystem;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess
{

    public interface IFileSystemAccessService<TFsFileHandle, TFsDirectoryHandle, TObjReference> : IAsyncDisposable
        where TFsFileHandle : FileSystemFileHandle
        where TFsDirectoryHandle : FileSystemDirectoryHandle
        where TObjReference : IJSObjectReference
    {
        Task<bool> IsSupportedAsync();

        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync();
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(FileSystemOptions fasOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemOptions fsOptions);
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemOptions fsOptions);

        Task<TFsFileHandle[]> ShowOpenFilePickerAsync();
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(FileSystemOptions fasOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemOptions fsOptions);
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemOptions fsOptions);

        Task<TFsFileHandle> ShowSaveFilePickerAsync();
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(FileSystemOptions fsOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemOptions fsOptions);
        Task<TFsFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemOptions fsOptions);
    }

    public interface IFileSystemAccessService : IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>
    {
    }
}