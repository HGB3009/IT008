using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InstagramInteraction
{
    
    internal class instagramBot
    {
        private IWebDriver driver;
        public instagramBot()
        {
            driver = new ChromeDriver();
        }

        public void Login(string username, string password)
        {
            // Mở trang đăng nhập
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
           
            IWebElement usernameInput = driver.FindElement(By.Name("username"));
            IWebElement passwordInput = driver.FindElement(By.Name("password"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            loginButton.Click();
        }
        public void AutoLike(string targetUsername)
        {
            // Mở trang cá nhân của người dùng cần like ảnh
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            // Code tự động thả tim ở đây
            // Lọc và click vào nút thả tim
        }

        public void AutoComment(string targetUsername, string comment)
        {
            // Mở trang cá nhân của người dùng cần bình luận
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            // Code tự động bình luận ở đây
            // Lọc và nhập nội dung bình luận, sau đó click vào nút gửi bình luận
        }

        public void AutoFollow(string targetUsername)
        {
            // Mở trang cá nhân của người dùng cần follow
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            // Code tự động follow ở đây
            // Lọc và click vào nút follow
        }
        public void Quit()
        {
            driver.Quit();
        }
    }
}
