var DotNetObject = {}
function showPrompt(text) {
    var result = prompt(text, 'Type your name here');
    //呼叫該 .NET 執行個體(由類別 BindDotNetInstance 所產生)的 SayHello 方法
    DotNetObject.invokeMethodAsync('SayHello', result);
}
function SetDotNetObjectJS(dotnetHelper) {
    //將該 .NET 執行個體設定成為 JavaScript 的全域變數
    DotNetObject = dotnetHelper;
}
