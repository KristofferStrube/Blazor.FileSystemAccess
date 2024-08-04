export function getAttribute(object, attribute) { return object[attribute]; }

export function forEachWithNoArguments(jSReference, callbackObjRef) {
    jSReference.forEach(() => callbackObjRef.invokeMethodAsync('InvokeCallback'))
}

export function forEachWithOneArgument(jSReference, callbackObjRef) {
    jSReference.forEach((value) => callbackObjRef.invokeMethodAsync('InvokeCallback', DotNet.createJSObjectReference(value)))
}

export function forEachWithTwoArguments(jSReference, callbackObjRef) {
    jSReference.forEach((value, key) => callbackObjRef.invokeMethodAsync('InvokeCallback', DotNet.createJSObjectReference(value, key)))
}

// https://javascriptweblog.wordpress.com/2011/08/08/fixing-the-javascript-typeof-operator/
export function valuePropertiesType(obj) {
    return ({}).toString.call(obj.value).match(/\s([a-z|A-Z]+)/)[1].toLowerCase();
}

export function valuePropertiesValue(obj) {
    return obj.value;
}