# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.0.0] - 2022-11-10
### Added
- Added interfaces for `FileSystemAccessService` and `FileSystemAccessServiceInProcess` so that they are test friendly.
- Added the following InProcess variants of wrapper classes: `FileSystemDirectoryHandle`, `FileSystemFileHandle`, `FileSystemHandle` and `FileSystemWritableFileStream`.

### Changed
- Changed the Blazor WebAssembly compatible service to be named `FileSystemAccessServiceInProcess` instead of `FileSystemAccessService` so that Blazor Server support is the standard.
- Changed to use the Blazor.FileAPI's definition of `Blob`s and `File`s.
- Changed to have `FileSystemWritableFileStream` extend Blazor.Streams's `WritableStream` instead of .NET `Stream`.
- Changed creator methods `CreateAsync` to take `IJSRuntime` first to normalize standards with other wrappers.

## [1.2.1] - 2022-10-10
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
