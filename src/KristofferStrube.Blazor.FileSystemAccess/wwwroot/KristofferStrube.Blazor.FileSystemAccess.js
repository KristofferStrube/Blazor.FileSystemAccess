export function size(array) { return array.length; }

export function getAttribute(object, attribute) { return object[attribute]; }

export async function arrayFrom(values) {
    var res = []
    for await (let value of values) {
        res.push(value);
    }
    return res;
}

export function writeBlobWriteParams(fileSystemWritableFileStream, writeParams, blob) {
    writeParams.data = blob;
    fileSystemWritableFileStream.write(writeParams);
}

export function getAsFileSystemHandle(dataTransferItem) {
    console.log(dataTransferItem);
    console.log(dataTransferItem.getAsString());
    return dataTransferItem.getAsFileSystemHandle();
}