namespace bzParameterResearch.Pages
{
    using Microsoft.AspNetCore.Components;
    public partial class NewCounter : Microsoft.AspNetCore.Components.ComponentBase
    {
        /// <summary>
        /// 這裡將會重新產生出最新狀態的轉譯樹
        /// </summary>
        /// <param name="__builder"></param>
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            System.Console.WriteLine($"  開始執行子元件的轉譯樹建立程序 BuildRenderTree : {currentCount}");
            __builder.AddMarkupContent(0, "<h1>New Counter</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Current count: ");
            __builder.AddContent(3,
                   currentCount
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-primary");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this,
                                          IncrementCount
            ));
            __builder.AddContent(8, "Click me");
            __builder.CloseElement();
        }

        /// <summary>
        /// 該 NewCounter 元件可以接收的參數
        /// </summary>
        [Parameter]
        public int currentCount { get; set; } = 0;

        /// <summary>
        /// 當參數要進行綁定的時候，將會觸發的生命週期事件
        /// </summary>
        protected override void OnParametersSet()
        {
            System.Console.WriteLine($"  子元件的參數綁定生命週期事件觸發了 OnParametersSet : {currentCount}");
        }

        /// <summary>
        /// 該元件畫面中按鈕所要綁定的點選該按鈕之觸發事件
        /// </summary>
        private void IncrementCount()
        {
            currentCount++;
        }

        /// <summary>
        /// 若直接取得該元件的參考，就可以呼叫這個公開方法，這裡是要來查看參數是否已經綁定成功了嗎？
        /// </summary>
        public void EchoCurrentCount()
        {
            System.Console.WriteLine($"  子元件內部的參數數值 : {currentCount}");
        }
    }
}
