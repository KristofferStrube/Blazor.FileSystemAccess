using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

internal class FileSystemAccessServiceInProcess :
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
        => await FileSystemDirectoryHandleInProcess.CreateAsync(jSRuntime, jSReference, options);

    protected override async Task<FileSystemFileHandleInProcess> CreateFileHandleAsync(IJSRuntime jSRuntime, IJSInProcessObjectReference jSReference, FileSystemAccessOptions options)
        => await FileSystemFileHandleInProcess.CreateAsync(jSRuntime, jSReference, options);

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.GetOriginPrivateDirectoryAsync()
        => await this.GetOriginPrivateDirectoryAsync();

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync()
        => await this.ShowDirectoryPickerAsync();

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions)
        => await this.ShowDirectoryPickerAsync(directoryPickerOptions);

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions)
        => await this.ShowDirectoryPickerAsync(directoryPickerOptions);

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(FileSystemAccessOptions fasOptions)
        => await this.ShowDirectoryPickerAsync(fasOptions);

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemAccessOptions fasOptions)
        => await this.ShowDirectoryPickerAsync(directoryPickerOptions, fasOptions);

    async Task<FileSystemDirectoryHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemAccessOptions fasOptions)
        => await this.ShowDirectoryPickerAsync(directoryPickerOptions, fasOptions);

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync()
        => await this.ShowOpenFilePickerAsync();

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions)
        => await this.ShowOpenFilePickerAsync(openFilePickerOptions);

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions)
        => await this.ShowOpenFilePickerAsync(openFilePickerOptions);

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(FileSystemAccessOptions fasOptions)
        => await this.ShowOpenFilePickerAsync(fasOptions);

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions, FileSystemAccessOptions fasOptions) 
        => await this.ShowOpenFilePickerAsync(openFilePickerOptions, fasOptions);

    async Task<FileSystemFileHandle[]> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInWellKnownDirectory? openFilePickerOptions, FileSystemAccessOptions fasOptions)
        => await this.ShowOpenFilePickerAsync(openFilePickerOptions, fasOptions);

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync()
        => await this.ShowSaveFilePickerAsync();

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions)
        => await this.ShowSaveFilePickerAsync(saveFilePickerOptions);

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions)
        => await this.ShowSaveFilePickerAsync(saveFilePickerOptions);

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(FileSystemAccessOptions fasOptions)
        => await this.ShowSaveFilePickerAsync(fasOptions);

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInFileSystemHandle? saveFilePickerOptions, FileSystemAccessOptions fasOptions)
        => await this.ShowSaveFilePickerAsync(saveFilePickerOptions, fasOptions);

    async Task<FileSystemFileHandle> IFileSystemAccessService<FileSystemFileHandle, FileSystemDirectoryHandle, IJSObjectReference>.ShowSaveFilePickerAsync(SaveFilePickerOptionsStartInWellKnownDirectory? saveFilePickerOptions, FileSystemAccessOptions fasOptions)
        => await this.ShowSaveFilePickerAsync(saveFilePickerOptions, fasOptions);
}
