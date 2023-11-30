using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            IWebElement usernameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
            IWebElement passwordInput = driver.FindElement(By.Name("password"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            loginButton.Click();

            wait.Until(driver => driver.Url.Contains("https://www.instagram.com/"));

            IWebElement notNowButton1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Not now']")));
            notNowButton1.Click();

            IWebElement notNowButton2 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button._a9--._ap36._a9_1")));
            notNowButton2.Click();
        }
        public void AutoComment(string targetUsername, string comment)
        {
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");
        }

        public void AutoLike(string targetUsername)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));

            var posts = driver.FindElements(By.CssSelector("div._aagw"));

            foreach (var post in posts)
            {
                post.Click();

                //Check if the post already be liked
                bool isLiked = driver.FindElements(By.CssSelector("span._aamw svg[aria-label='Like'].filled-heart")).Any();

                if (!isLiked)
                {
                    driver.FindElement(By.CssSelector("span._aamw svg[aria-label='Like']")).Click();
                
                }
                // Wait for the like action to complete
                Task.Delay(2000).Wait();

                //Click on the close button
                IWebElement closeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.x1i10hfl button")));
                closeButton.Click();

                // Wait for the next post to be visible
                Task.Delay(5000).Wait();

            }
        }

        public void AutoDownPicCmt(string targetUsername, string comment)
        {
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            
        }

        public void AutoFollow(string targetUsername)
        {
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
