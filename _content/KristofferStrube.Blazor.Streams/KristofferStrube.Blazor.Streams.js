export function getAttribute(object, attribute) { return object[attribute]; }

export function setAttribute(object, attribute, value) { return object[attribute] = value; }

export function elementAt(array, index) { return array.at(index); }

export function constructReadableStreamDefaultReader(stream) {
    return new ReadableStreamDefaultReader(stream);
}

export function constructReadableStreamBYOBReader(stream) {
    return new ReadableStreamBYOBReader(stream);
}

export function constructReadableWritablePair(readable, writable) {
    return { readable: readable, writable: writable };
}

export function constructReadableStream(underlyingSource, strategy) {
    if (underlyingSource == null) {
        if (strategy == null) {
            return new ReadableStream();
        }
        return new ReadableStream(null, queueingStrategy(strategy));
    }
    var source = {
        start(controller) {
            underlyingSource.objRef.invokeMethodAsync('InvokeStart', DotNet.createJSObjectReference(controller));
        },
        pull(controller) {
            underlyingSource.objRef.invokeMethodAsync('InvokePull', DotNet.createJSObjectReference(controller));
        },
        cancel() {
            underlyingSource.objRef.invokeMethodAsync('InvokeCancel');
        },
    };
    if (strategy == null) {
        return new ReadableStream(source);
    }
    return new ReadableStream(source, queueingStrategy(strategy));
}

export function constructWritableStream(underlyingSink, strategy) {
    if (underlyingSink == null) {
        return new WritableStream(null, queueingStrategy(strategy));
    }
    var sink = {
        start(controller) {
            underlyingSink.objRef.invokeMethodAsync('InvokeStart', DotNet.createJSObjectReference(controller));
        },
        write(chunk, controller) {
            underlyingSink.objRef.invokeMethodAsync('InvokeWrite', DotNet.createJSObjectReference(chunk), DotNet.createJSObjectReference(controller));
        },
        close() {
            underlyingSink.objRef.invokeMethodAsync('InvokeClose');
        },
        abort() {
            underlyingSink.objRef.invokeMethodAsync('InvokeAbort');
        },
    };
    return new WritableStream(sink, queueingStrategy(strategy));
}

export function constructTransformStream(underlyingSink, writableStrategy, readableStrategy) {
    if (underlyingSink == null) {
        return new TransformStream(null, queueingStrategy(writableStrategy), queueingStrategy(readableStrategy));
    }
    var sink = {
        start(controller) {
            underlyingSink.objRef.invokeMethodAsync('InvokeStart', DotNet.createJSObjectReference(controller));
        },
        write(chunk, controller) {
            underlyingSink.objRef.invokeMethodAsync('InvokeWrite', DotNet.createJSObjectReference(chunk), DotNet.createJSObjectReference(controller));
        },
        close() {
            underlyingSink.objRef.invokeMethodAsync('InvokeClose');
        },
        abort() {
            underlyingSink.objRef.invokeMethodAsync('InvokeAbort');
        },
    };
    return new TransformStream(sink, queueingStrategy(writableStrategy), queueingStrategy(readableStrategy));
}

function queueingStrategy(strategy) {
    if (strategy == null) {
        return {};
    }
    if (strategy instanceof ByteLengthQueuingStrategy || strategy instanceof CountQueuingStrategy) {
        return strategy;
    }
    return {
        highWaterMark: strategy.highWaterMark,
        size: (chunk) => strategy.objRef.invokeMethod('InvokeSize', DotNet.createJSObjectReference(chunk))
    };
}

export function constructWritableStreamDefaultReader(stream) {
    return new WritableStreamDefaultReader(stream);
}

export function constructByteLengthQueuingStrategy(init) {
    return new ByteLengthQueuingStrategy(init);
}

export function constructCountQueuingStrategy(init) {
    return new CountQueuingStrategy(init);
}

export function constructByteArray(size) {
    return new Uint8Array(size);
}

export function byteArray(object) {
    var bytes = new Uint8Array(object);
    return bytes;
}

export function valueOf(object) {
    return object;
}