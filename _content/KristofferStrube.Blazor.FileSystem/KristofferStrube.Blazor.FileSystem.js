export function size(array) { return array.length; }

export function getAttribute(object, attribute) { return object[attribute]; }

export async function arrayFrom(values) {
    var res = []
    for await (let value of values) {
        res.push(value);
    }
    return res;
}

export async function arrayBuffer(blob) {
    var buffer = await blob.arrayBuffer();
    var bytes = new Uint8Array(buffer);
    return bytes;
}