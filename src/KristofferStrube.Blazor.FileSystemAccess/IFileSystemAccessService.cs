using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess
{
    public interface IFileSystemAccessService
    {
        ValueTask DisposeAsync();
        Task<FileSystemDirectoryHandle> GetOriginPrivateDirectoryAsync();
        Task<bool> IsSupportedAsync();
        Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync();
        Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions = null);
        Task<FileSystemDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions = null);
        Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync();
        Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions = null);
        Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions = null);
        Task<FileSystemFileHandle> ShowSaveFilePickerAsync();
        Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions = null);
        Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions = null);

        #region Create Handle Instances 

        FileSystemDirectoryHandle CreateDirectoryHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference);
        FileSystemFileHandle CreateFileHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference);
        Task<FileSystemFileHandleInProcess> CreateFileHandleInProcessAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference);
        FileSystemHandle CreateFileSystemHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference);
        Task<FileSystemHandleInProcess> CreateFileSystemHandleInProcessAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference);

        #endregion
    }
}