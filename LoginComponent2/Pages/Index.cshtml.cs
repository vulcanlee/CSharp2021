using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LoginComponent.Pages
{
    public class IndexModel : PageModel
    {
        public LoginData LoginData { get; set; } = new();

        [BindProperty]
        public string Account { get; set; } = "123";

        [BindProperty]
        public string Password { get; set; } = "";
        [BindProperty]
        public string Captcha { get; set; } = "";
        [BindProperty]
        public string CaptchaOrigin { get; set; } = "";

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var fooLoginData = Request.Cookies["LoginData"];
            if (fooLoginData != null)
            {
                Byte[] bytesDecode = Convert.FromBase64String(fooLoginData); // 還原 Byte
                string resultText = System.Text.Encoding.UTF8.GetString(bytesDecode);

                LoginData loginData = JsonSerializer.Deserialize<LoginData>(resultText);
                string postModel = JsonSerializer.Serialize(loginData);
                Response.Cookies.Delete("LoginData");
            }
        }
    }
}