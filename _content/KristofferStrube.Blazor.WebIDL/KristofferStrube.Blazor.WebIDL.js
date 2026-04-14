export function getAttribute(object, attribute) { return object[attribute]; }

export function copyAttributeToNewObject(object, attribute) {
    let result = {};
    result[attribute] = object[attribute];
    return result;
}

export function forEachWithNoArguments(jSReference, callbackObjRef) {
    jSReference.forEach(() => callbackObjRef.invokeMethodAsync('InvokeCallback'))
}

export function forEachWithOneArgument(jSReference, callbackObjRef, valueIsJSObjectReference) {
    jSReference.forEach(
        async (value) => {
            await callbackObjRef.invokeMethodAsync(
                valueIsJSObjectReference ? 'InvokeCallbackJSObjectReference' : 'InvokeCallbackObject',
                valueIsJSObjectReference ? DotNet.createJSObjectReference(value) : value
            )
        })
}

export function forEachWithTwoArguments(jSReference, callbackObjRef, valueIsJSObjectReference, keyIsJSObjectReference) {
    let callbackMethodName = 'InvokeCallbackObjectObject';

    if (valueIsJSObjectReference && keyIsJSObjectReference) {
        callbackMethodName = 'InvokeCallbackJSObjectReferenceJSObjectReference'
    }
    else if (valueIsJSObjectReference) {
        callbackMethodName = 'InvokeCallbackJSObjectReferenceObject'
    }
    else if (keyIsJSObjectReference) {
        callbackMethodName = 'InvokeCallbackObjectJSObjectReference'
    }

    jSReference.forEach(
        async (value, key) => {
            await callbackObjRef.invokeMethodAsync(
                callbackMethodName,
                valueIsJSObjectReference ? DotNet.createJSObjectReference(value) : value,
                keyIsJSObjectReference ? DotNet.createJSObjectReference(key) : key
            )
        })
}

// https://javascriptweblog.wordpress.com/2011/08/08/fixing-the-javascript-typeof-operator/
export function valuePropertiesType(obj, attribute) {
    return ({}).toString.call(obj[attribute]).match(/\s([a-z|A-Z]+)/)[1].toLowerCase();
}

export function valueType(obj) {
    return ({}).toString.call(obj).match(/\s([a-z|A-Z]+)/)[1].toLowerCase();
}

export function constructUint8Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Uint8Array();
    }
    else if (arg2 == null) {
        return new Uint8Array(arg1);
    }
    else if (arg3 == null) {
        return new Uint8Array(arg1, arg2);
    }
    else {
        return new Uint8Array(arg1, arg2, arg3);
    }
}

export function constructUint16Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Uint16Array();
    }
    else if (arg2 == null) {
        return new Uint16Array(arg1);
    }
    else if (arg3 == null) {
        return new Uint16Array(arg1, arg2);
    }
    else {
        return new Uint16Array(arg1, arg2, arg3);
    }
}

export function constructUint32Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Uint32Array();
    }
    else if (arg2 == null) {
        return new Uint32Array(arg1);
    }
    else if (arg3 == null) {
        return new Uint32Array(arg1, arg2);
    }
    else {
        return new Uint32Array(arg1, arg2, arg3);
    }
}

export function constructInt8Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Int8Array();
    }
    else if (arg2 == null) {
        return new Int8Array(arg1);
    }
    else if (arg3 == null) {
        return new Int8Array(arg1, arg2);
    }
    else {
        return new Int8Array(arg1, arg2, arg3);
    }
}

export function constructInt16Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Int16Array();
    }
    else if (arg2 == null) {
        return new Int16Array(arg1);
    }
    else if (arg3 == null) {
        return new Int16Array(arg1, arg2);
    }
    else {
        return new Int16Array(arg1, arg2, arg3);
    }
}

export function constructInt32Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Int32Array();
    }
    else if (arg2 == null) {
        return new Int32Array(arg1);
    }
    else if (arg3 == null) {
        return new Int32Array(arg1, arg2);
    }
    else {
        return new Int32Array(arg1, arg2, arg3);
    }
}
export function constructFloat32Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Float32Array();
    }
    else if (arg2 == null) {
        return new Float32Array(arg1);
    }
    else if (arg3 == null) {
        return new Float32Array(arg1, arg2);
    }
    else {
        return new Float32Array(arg1, arg2, arg3);
    }
}

export function constructFloat64Array(arg1 = null, arg2 = null, arg3 = null) {
    if (arg1 == null) {
        return new Float64Array();
    }
    else if (arg2 == null) {
        return new Float64Array(arg1);
    }
    else if (arg3 == null) {
        return new Float64Array(arg1, arg2);
    }
    else {
        return new Float64Array(arg1, arg2, arg3);
    }
}

export function constructArrayBuffer(length) {
    return new ArrayBuffer(length)
}

export function constructSharedArrayBuffer(length) {
    return new SharedArrayBuffer(length)
}

export function constructDomException(message, name) {
    return new DOMException(message, name);
}

export function constructEvalError(message) {
    return EvalError(message);
}

export function constructRangeError(message) {
    return RangeError(message);
}

export function constructReferenceError(message) {
    return ReferenceError(message);
}

export function constructTypeError(message) {
    return TypeError(message);
}

export function constructURIError(message) {
    return URIError(message);
}

export async function callAsyncGlobalMethod(extraErrorProperties, identifier, args) {
    return await callAsyncInstanceMethod(extraErrorProperties, window, identifier, args);
}

export async function callAsyncInstanceMethod(extraErrorProperties, instance, identifier, args) {
    try {
        if (instance == window && identifier == "import" && args.length == 1) {
            if (args[0].startsWith("./")) {
                return await import("../." + args);
            }
            else if (args[0].startsWith("/")) {
                return await import("../.." + args);
            }
            else {
                return await import("../../" + args);
            }
        }
        var [functionObject, functionInstance] = resolveFunction(instance, identifier);
        return await functionInstance.apply(functionObject, args);
    }
    catch (error) {
        throw new DOMException(formatError(error, extraErrorProperties), "AbortError");
    }
}

export function callGlobalMethod(extraErrorProperties, identifier, args) {
    return callInstanceMethod(extraErrorProperties, window, identifier, args);
}

export function callInstanceMethod(extraErrorProperties, instance, identifier, args) {
    try {
        var [functionObject, functionInstance] = resolveFunction(instance, identifier);
        return functionInstance.apply(functionObject, args);
    }
    catch (error) {
        throw new DOMException(formatError(error, extraErrorProperties), "AbortError");
    }
}

function resolveFunction(instance, identifier)
{
    let identifierParts = identifier.split(".");
    var functionObject = instance;
    var functionInstance = instance[identifierParts[0]];
    for (let i = 1; i < identifierParts.length; i++) {
        if (functionInstance == undefined) {
            throw new ReferenceError(`Cannot read properties of undefined (reading '${identifierParts[i - 1]}').`);
        }
        functionObject = functionInstance;
        functionInstance = functionInstance[identifierParts[i]];
    }
    if (!(functionInstance instanceof Function)) {
        throw new TypeError(`'${identifierParts.slice(-1)}' is not a function.`);
    }
    return [functionObject, functionInstance];
}

function formatError(error, extraErrorProperties) {
    var name = error.name;
    if (error instanceof DOMException && name == "SyntaxError") {
        name = "DOMExceptionSyntaxError";
    };
    let copy = {
        name: name,
        message: error.message,
        stack: error.stack,
    };
    extraErrorProperties?.forEach(property => copy[property] = error[property]);
    return JSON.stringify(copy);
}