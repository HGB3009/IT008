using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace InstagramInteraction
{
    
    internal class instagramBot
    {
        private IWebDriver driver;
        public instagramBot()
        {
            driver = new ChromeDriver();
        }

        public bool Login(string username, string password)
        {
            
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
           
            IWebElement usernameInput = driver.FindElement(By.Name("Phone number, username"));
            IWebElement passwordInput = driver.FindElement(By.Name("Password"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            loginButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.Url.Contains("https://www.instagram.com/"));

            return driver.Url.Contains("instagram.com");

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
