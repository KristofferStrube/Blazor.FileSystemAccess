# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Added
- `FileSystemWritableStream` now extends the `Stream`.
### Added
- Added support for Origin Private File System via `GetOriginPrivateDirectory` method that wraps the JS call `navigator.storage.getDirectory`.
### Changed
- Changed `RemoveEntryAsync` to use `FileSystemRemoveOptions` instead of `FileSystemGetFileOptions` and created the `FileSystemRemoveOptions` class.
### Removed
- Constructor with `keepExistingData` parameter in `FileSystemCreateWritableOptions` was removed for consistency.

## [0.2.0] - 2022-06-14
### Added
- Added support for writing byte arrays to files using `FileSystemWritableFileStream`. By [@nzmangan](https://github.com/nzmangan).
