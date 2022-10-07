# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Fixed
- Fixed that `BlobWriteParams`, `StringWriteParams`, and `ByteArrayWriteParams` didn't set their `WriteCommandType` given from the constructor.
- Fixed naming of `GetOriginPrivateDirectoryAsync` and `IsSupportedAsync` to have _Async_ in name.

## [1.2.0] - 2022-10-07
### Added
- Added `ArrayBufferAsync` method to `Blob` to read as byte array. By [@fixnil](https://github.com/fixnil).
- Added public `CreateAsync` methods to `FileSystemHandle`, `FileSystemFileHandle`, and `FileSystemDirectoryHandle`.
### Fixed
- Fixed naming of `QueryPermissionAsync` and `RequestPermissionAsync` to have _Async_ in name.
- Fixed that there was an extra _in_ in the name of `OpenFilePickerOptionsStartInFileSystemHandle`.

## [1.1.0] - 2022-08-19
### Added
- `FileSystemWritableFileStream` now extends the `Stream`.

## [1.0.1] - 2022-07-12
### Fixed
- Fixed error of `Multiple` in `OpenFilePickerOptionsStartInWellKnownDirectory` not being serialized correctly. By [@AlexanderNorup](https://github.com/AlexanderNorup).

## [1.0.0] - 2022-06-28
### Added
- Added support for Origin Private File System via `GetOriginPrivateDirectory` method that wraps the JS call `navigator.storage.getDirectory`.
### Changed
- Changed `RemoveEntryAsync` to use `FileSystemRemoveOptions` instead of `FileSystemGetFileOptions` and created the `FileSystemRemoveOptions` class.
### Removed
- Constructor with `keepExistingData` parameter in `FileSystemCreateWritableOptions` was removed for consistency.

## [0.2.0] - 2022-06-14
### Added
- Added support for writing byte arrays to files using `FileSystemWritableFileStream`. By [@nzmangan](https://github.com/nzmangan).
