export function getAttribute(object, attribute) { return object[attribute]; }

export function arrayBuffer(buffer) {
    var bytes = new Uint8Array(buffer);
    return bytes;
}

export function constructBlob(blobParts, options) {
    return new Blob(blobParts, options);
}

export function constructFile(blobParts, fileName, options) {
    return new File(blobParts, fileName, options);
}

export function constructFileReader() {
    return new FileReader();
}

export function registerEventHandlersAsync(objRef, jSInstance) {
    jSInstance.addEventListener('loadstart', (e) => objRef.invokeMethodAsync('InvokeOnLoadStartAsync', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('progress', (e) => objRef.invokeMethodAsync('InvokeOnProgressAsync', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('load', (e) => objRef.invokeMethodAsync('InvokeOnLoadAsync', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('abort', (e) => objRef.invokeMethodAsync('InvokeOnAbortAsync', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('error', (e) => objRef.invokeMethodAsync('InvokeOnErrorAsync', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('loadend', (e) => objRef.invokeMethodAsync('InvokeOnLoadEndAsync', DotNet.createJSObjectReference(e)));
}

export function registerEventHandlers(objRef, jSInstance) {
    jSInstance.addEventListener('loadstart', (e) => objRef.invokeMethod('InvokeOnLoadStart', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('progress', (e) => objRef.invokeMethod('InvokeOnProgress', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('load', (e) => objRef.invokeMethod('InvokeOnLoad', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('abort', (e) => objRef.invokeMethod('InvokeOnAbort', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('error', (e) => objRef.invokeMethod('InvokeOnError', DotNet.createJSObjectReference(e)));
    jSInstance.addEventListener('loadend', (e) => objRef.invokeMethod('InvokeOnLoadEnd', DotNet.createJSObjectReference(e)));
}

export function isArrayBuffer(fileReader) {
    return (fileReader.result instanceof ArrayBuffer)
}