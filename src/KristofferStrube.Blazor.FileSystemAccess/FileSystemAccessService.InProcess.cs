using KristofferStrube.Blazor.FileSystem;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

public class FileSystemAccessServiceInProcess :
    BaseFileSystemAccessService<
        FileSystemFileHandleInProcess,
        FileSystemDirectoryHandleInProcess,
        IJSInProcessObjectReference>,
    IFileSystemAccessServiceInProcess, IFileSystemAccessService
{
    public FileSystemAccessServiceInProcess(IJSRuntime jSRuntime) : base(jSRuntime)
    {
    }

    protected override async Task<FileSystemDirectoryHandleInProcess> CreateDirectoryHandleAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemOptions options)
    {
        return await FileSystemDirectoryHandleInProcess.CreateAsync(jSRuntime, jSReference, options);
    }

    protected override async Task<FileSystemFileHandleInProcess> CreateFileHandleAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemOptions options)
    {
        return await FileSystemFileHandleInProcess.CreateAsync(jSRuntime, jSReference, options);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync()
    {
        return await this.ShowDirectoryPickerAsync();
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions)
    {
        return await this.ShowDirectoryPickerAsync(directoryPickerOptions);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions)
    {
        return await this.ShowDirectoryPickerAsync(directoryPickerOptions);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(FileSystemOptions fsOptions)
    {
        return await this.ShowDirectoryPickerAsync(fsOptions);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemOptions fsOptions)
    {
        return await this.ShowDirectoryPickerAsync(directoryPickerOptions, fsOptions);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemOptions fsOptions)
    {
        return await this.ShowDirectoryPickerAsync(directoryPickerOptions, fsOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync()
    {
        return await this.ShowOpenFilePickerAsync();
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions)
    {
        return await this.ShowOpenFilePickerAsync(openFilePickerOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions)
    {
        return await this.ShowOpenFilePickerAsync(openFilePickerOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(FileSystemOptions fsOptions)
    {
        return await this.ShowOpenFilePickerAsync(fsOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await this.ShowOpenFilePickerAsync(openFilePickerOptions, fsOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await this.ShowOpenFilePickerAsync(openFilePickerOptions, fsOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync()
    {
        return await this.ShowSaveFilePickerAsync();
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions)
    {
        return await this.ShowSaveFilePickerAsync(saveFilePickerOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions)
    {
        return await this.ShowSaveFilePickerAsync(saveFilePickerOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(FileSystemOptions fsOptions)
    {
        return await this.ShowSaveFilePickerAsync(fsOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await this.ShowSaveFilePickerAsync(saveFilePickerOptions, fsOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemOptions fsOptions)
    {
        return await this.ShowSaveFilePickerAsync(saveFilePickerOptions, fsOptions);
    }
}
