using KristofferStrube.Blazor.FileSystem;
using KristofferStrube.Blazor.WebIDL.Exceptions;
using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess
{

    public interface IFileSystemAccessService<TFsFileHandle, TFsDirectoryHandle, TObjReference> : IAsyncDisposable
        where TFsFileHandle : FileSystemFileHandle
        where TFsDirectoryHandle : FileSystemDirectoryHandle
        where TObjReference : IJSObjectReference
    {
        Task<bool> IsSupportedAsync();

        /// <summary>
        /// Shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission.
        /// </summary>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync();

        /// <summary>
        /// Shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission. If the <paramref name="directoryPickerOptions"/> argument specified that it should have write access as well this needs to be confirmed by the user as well.
        /// </summary>
        /// <param name="directoryPickerOptions">A directory picker options for selecting to start in the position of an existing <see cref="FileSystemHandle"/>.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="TypeErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions);

        /// <summary>
        /// Shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission. If the <paramref name="directoryPickerOptions"/> argument specified that it should have write access as well this needs to be confirmed by the user as well.
        /// </summary>
        /// <param name="directoryPickerOptions">A directory picker options for selecting to start in one of the cross-browser well-known directories.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="TypeErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions);

        /// <summary>
        /// Shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission.
        /// </summary>
        /// <param name="fsOptions">An option that can be used to define the path of the helper script used in this library.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(FileSystemOptions fsOptions);

        /// <summary>
        /// Shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission. If the <paramref name="directoryPickerOptions"/> argument specified that it should have write access as well this needs to be confirmed by the user as well.
        /// </summary>
        /// <param name="directoryPickerOptions">A directory picker options for selecting to start in the position of an existing <see cref="FileSystemHandle"/>.</param>
        /// <param name="fsOptions">An option that can be used to define the path of the helper script used in this library.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="TypeErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInFileSystemHandle? directoryPickerOptions, FileSystemOptions fsOptions);

        /// <summary>
        /// Shows a directory picker that lets the user select a single directory, returning a handle for the selected directory if the user grants read permission. If the <paramref name="directoryPickerOptions"/> argument specified that it should have write access as well this needs to be confirmed by the user as well.
        /// </summary>
        /// <param name="directoryPickerOptions">A directory picker options for selecting to start in one of the cross-browser well-known directories.</param>
        /// <param name="fsOptions">An option that can be used to define the path of the helper script used in this library.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="TypeErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsDirectoryHandle> ShowDirectoryPickerAsync(DirectoryPickerOptionsStartInWellKnownDirectory? directoryPickerOptions, FileSystemOptions fsOptions);

        /// <summary>
        /// Shows a file picker that lets a user select a single existing file, returning a handle for the selected file.
        /// </summary>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemDirectoryHandle"/></returns>
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync();

        /// <summary>
        /// Shows a file picker that lets a user select a single existing file, if the parsed <paramref name="openFilePickerOptions"/> argument had multiple set to <see langword="false"/>, returning a handle for the selected file. If the <paramref name="openFilePickerOptions"/> argument specified that the user could pick multiple files then there might be more than a single handle returned.
        /// </summary>
        /// <param name="openFilePickerOptions">A file picker options for selecting to start in the position of an existing <see cref="FileSystemHandle"/>.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="TypeErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemFileHandle"/></returns>
        Task<TFsFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptionsStartInFileSystemHandle? openFilePickerOptions);

        /// <summary>
        /// Shows a file picker that lets a user select a single existing file, if the parsed <paramref name="openFilePickerOptions"/> argument had multiple set to <see langword="false"/>, returning a handle for the selected file. If the <paramref name="openFilePickerOptions"/> argument specified that the user could pick multiple files then there might be more than a single handle returned.
        /// </summary>
        /// <param name="openFilePickerOptions">A file picker options for selecting to start in one of the cross-browser well-known directories.</param>
        /// <exception cref="AbortErrorException"/>
        /// <exception cref="TypeErrorException"/>
        /// <exception cref="SecurityErrorException"/>
        /// <returns>A new <see cref="FileSystemFileHandle"/></returns>
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