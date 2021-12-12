using System.Drawing;
using System.Drawing.Imaging;

namespace LoginComponent.Pages
{
    public class CaptchaHelper
    {
        #region 產生驗證碼
        public (string CaptchaOrigin, string CaptchaImage) GetCaptchaImage()
        {
            int length = 4;
            string captchaCode = CreateRandomCode(length);
            string CaptchaOrigin = GetCaptchaSHA(captchaCode);
            string CaptchaImage = CreateCaptchaImage(captchaCode);
            return (CaptchaOrigin, CaptchaImage);
        }

        string CreateRandomCode(int length)
        {
            string randomCode = "";
            for (int i = 0; i < length; i++)
            {
                randomCode += new Random().Next(9);
            }
            return randomCode;
        }

        string CreateCaptchaImage(string captcha)
        {
            Bitmap bitmap = new Bitmap(120, 50);
            Graphics graphics = Graphics.FromImage(bitmap);
            Random random = new Random();
            string result = "";
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    graphics.Clear(Color.DarkGray);
                    for (int i = 0; i < 10; i++)
                    {
                        Pen whitePen = new Pen(Brushes.White,
                            random.Next(1, 4));
                        int x1 = random.Next(bitmap.Width);
                        int x2 = random.Next(bitmap.Width);
                        int y1 = random.Next(bitmap.Height);
                        int y2 = random.Next(bitmap.Height);
                        graphics.DrawLine(whitePen, x1, y1, x2, y2);
                    }

                    Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                    int startX = random.Next(0, 25);
                    int startY = random.Next(0, 8);
                    graphics.DrawString(captcha, new Font("Tahoma", 30), Brushes.White, startX, startY);

                    bitmap.Save(stream, ImageFormat.Jpeg);
                    byte[] imageBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    result = "data:image/png;base64," + base64String;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        string GetCaptchaSHA(string captcha)
        {
            // 在此作該驗證碼的保護
            return captcha;
        }
        #endregion
    }
}
