namespace bzParameterResearch.Pages
{
    using Microsoft.AspNetCore.Components;
    public partial class NewCounter : Microsoft.AspNetCore.Components.ComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            System.Console.WriteLine($"BuildRenderTree : {currentCount}");
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

        [Parameter]
        public int currentCount { get; set; } = 0;
        protected override void OnParametersSet()
        {
            System.Console.WriteLine($"OnParametersSet : {currentCount}");
        }
        private void IncrementCount()
        {
            currentCount++;
        }

        public void EchoCurrentCount()
        {
            System.Console.WriteLine($"Current Count : {currentCount}");
        }
    }
}
#pragma warning restore 1591
