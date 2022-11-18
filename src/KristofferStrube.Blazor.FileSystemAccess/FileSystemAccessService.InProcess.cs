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

    protected override async Task<FileSystemDirectoryHandleInProcess> CreateDirectoryHandleAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemAccessOptions options)
    {
        return await FileSystemDirectoryHandleInProcess.CreateAsync(jSRuntime, jSReference, options);
    }

    protected override async Task<FileSystemFileHandleInProcess> CreateFileHandleAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemAccessOptions options)
    {
        return await FileSystemFileHandleInProcess.CreateAsync(jSRuntime, jSReference, options);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.GetOriginPrivateDirectoryAsync()
    {
        return await this.GetOriginPrivateDirectoryAsync();
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

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(FileSystemAccessOptions fasOptions)
    {
        return await this.ShowDirectoryPickerAsync(fasOptions);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await this.ShowDirectoryPickerAsync(directoryPickerOptions, fasOptions);
    }

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await this.ShowDirectoryPickerAsync(directoryPickerOptions, fasOptions);
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

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(FileSystemAccessOptions fasOptions)
    {
        return await this.ShowOpenFilePickerAsync(fasOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await this.ShowOpenFilePickerAsync(openFilePickerOptions, fasOptions);
    }

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await this.ShowOpenFilePickerAsync(openFilePickerOptions, fasOptions);
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

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(FileSystemAccessOptions fasOptions)
    {
        return await this.ShowSaveFilePickerAsync(fasOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await this.ShowSaveFilePickerAsync(saveFilePickerOptions, fasOptions);
    }

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemAccessOptions fasOptions)
    {
        return await this.ShowSaveFilePickerAsync(saveFilePickerOptions, fasOptions);
    }
}
