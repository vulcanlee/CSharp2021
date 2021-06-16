namespace bzParameterResearch.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Components.Web.Virtualization;
    using Microsoft.JSInterop;
    using bzParameterResearch;
    using bzParameterResearch.Shared;
    [Microsoft.AspNetCore.Components.RouteAttribute("/IndexRaw")]
    public partial class IndexRaw : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            System.Console.WriteLine($"IndexRaw 元件的轉譯樹建立程序 BuildRenderTree");
            __builder.AddMarkupContent(0, "<h1>Hello, 參數資料綁定與轉譯樹之深入研究!</h1>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "card");
            __builder.AddMarkupContent(3, "<div class=\"card-header\">\r\n        使用 .razor 檔案設計的 Razor 元件\r\n    </div>\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "card-body");
            __builder.OpenComponent<bzParameterResearch.Pages.Counter>(6);
            __builder.AddAttribute(7, "currentCount", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
                                counterNumber
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "card");
            __builder.AddMarkupContent(11, "<div class=\"card-header\">\r\n        使用 C# 設計的 Razor 元件\r\n    </div>\r\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "card-body");
            __builder.OpenComponent<bzParameterResearch.Pages.NewCounter>(14);
            __builder.AddAttribute(15, "currentCount", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
                                                     counterNumber
            ));
            __builder.AddComponentReferenceCapture(16, (__value) => {
                NewCounter = (bzParameterResearch.Pages.NewCounter)__value;
            }
            );
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "my-4");
            __builder.OpenElement(20, "button");
            __builder.AddAttribute(21, "class", "btn btn-primary");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this,
                                              Reset
            ));
            __builder.AddMarkupContent(23, "重新設定");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n    ");
            __builder.OpenElement(25, "button");
            __builder.AddAttribute(26, "class", "btn btn-primary mx-3");
            __builder.AddAttribute(27, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this,
                                                   ResetAsync
            ));
            __builder.AddMarkupContent(28, "非同步重新設定");
            __builder.CloseElement();
            __builder.CloseElement();
        }

        public int counterNumber { get; set; }
        public NewCounter NewCounter { get; set; }
        void Reset()
        {
            //Console.WriteLine($"將計數器強制修正為 100");
            //counterNumber = 100;
            //NewCounter.EchoCurrentCount();
            Console.WriteLine($"沒有任何異動");
            NewCounter.EchoCurrentCount();
            StateHasChanged();
        }

        async Task ResetAsync()
        {
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine($"將計數器強制修正為 50");
            counterNumber = 50;
            NewCounter.EchoCurrentCount();
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            NewCounter.EchoCurrentCount();
            Console.WriteLine($"將計數器強制修正為 100");
            counterNumber = 100;
            NewCounter.EchoCurrentCount();
            //Console.WriteLine($"將計數器強制修正為 50");
            //counterNumber = 100;
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            counterNumber = 100;
            NewCounter.EchoCurrentCount();
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            counterNumber = 1;
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            counterNumber = 2;
            //Console.WriteLine("StateHasChanged()");
            //StateHasChanged();
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            counterNumber = 3;
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            counterNumber = 4;
            Console.WriteLine("Launch Task.Delay(100)");
            await Task.Delay(100);
            counterNumber = 5;
        }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
