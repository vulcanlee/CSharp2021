using Microsoft.JSInterop;

namespace LoginComponent.Pages
{
    public class CookieHelper
    {
        public CookieHelper(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }
        string expires = "";
        public async Task SetValue(string key, string value, int? seconds = null)
        {
            var curExp = (seconds != null) ? (seconds > 0 ? DateToUTC(seconds.Value) : "") : expires;
            await SetCookie($"{key}={value}; expires={curExp}; path=/");
        }
        public async Task SetCookie(string value)
        {
            await JSRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{value}\"");
        }
        public int ExpireDays
        {
            set => expires = DateToUTC(value);
        }
        public IJSRuntime JSRuntime { get; }

        public static string DateToUTC(int seconds) => DateTime.Now.AddSeconds(seconds).ToUniversalTime().ToString("R");
    }
}
