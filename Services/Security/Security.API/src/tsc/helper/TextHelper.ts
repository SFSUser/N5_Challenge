export default class TextHelper {
    public static trimText(text: string, size: number = 100){
        var element = document.createElement("div");
        element.innerHTML = text;
        return element.innerText.slice(0, size) + (element.innerText.length > size ? "..." : "");
    }
}