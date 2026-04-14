export function getAttribute(object, attribute) { return object[attribute]; }
export function setAttribute(object, attribute, value) { object[attribute] = value; }

export function getJSReference(element) { return element.valueOf(); }

export function constructEventListener() {
    return { };
}

export function registerEventHandlerAsync(objRef, jSInstance) {
    jSInstance.handleEvent = (e) => objRef.invokeMethodAsync("HandleEventAsync", DotNet.createJSObjectReference(e))
}

export function registerInProcessEventHandlerAsync(objRef, jSInstance) {
    jSInstance.handleEvent = (e) => objRef.invokeMethodAsync("HandleEventInProcessAsync", DotNet.createJSObjectReference(e))
}

export function constructEvent(type, eventInitDict = null) {
    return new Event(type, eventInitDict);
}

export function constructCustomEvent(type, eventInitDict = null) {
    return new CustomEvent(type, eventInitDict);
}

export function constructEventTarget() { return new EventTarget(); }

export function constructAbortController() { return new AbortController(); }