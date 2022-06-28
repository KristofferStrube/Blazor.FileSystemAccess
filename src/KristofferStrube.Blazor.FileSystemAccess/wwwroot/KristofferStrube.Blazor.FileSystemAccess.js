export function size(array) { return array.length; }

export function getAttribute(object, attribute) { return object[attribute]; }

export async function arrayFrom(values) {
    var res = []
    for await (let value of values) {
        res.push(value);
    }
    return res;
}

export function WriteBlobWriteParams(fileSystemWritableFileStream, writeParams, blob) {
    writeParams.data = blob;
    fileSystemWritableFileStream.write(writeParams);
}

// Methods for FileSystemWritableFileStream

export function close(fileSystemWritableFileStream) {
    fileSystemWritableFileStream.close();
}

export function seek(fileSystemWritableFileStream, position) {
    fileSystemWritableFileStream.seek(position);
}

export function truncate(fileSystemWritableFileStream, size) {
    fileSystemWritableFileStream.seek(size);
}

export function write(fileSystemWritableFileStream, buffer, offset) {
    var writeParams = {
        type: "write",
        position: offset,
        data: buffer
    };
    fileSystemWritableFileStream.write(writeParams);
}