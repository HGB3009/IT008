using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Windows.Forms.LinkLabel;

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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));


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
        public void Logout()
        {
            IWebElement settingButton = driver.FindElement(By.CssSelector("div.x9f619.x6s0dn4 svg[aria-label='Settings']"));

            settingButton.Click();
        }

        public void AutoComment(string targetUsername, string comment)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            //Select each post
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ScrollDown(js);

            var posts = driver.FindElements(By.CssSelector("div._aagw"));

            //Choose a random cmt
            string[] lines = comment.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            Random random = new Random();
            

            foreach (var post in posts)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(post));
                js.ExecuteScript("arguments[0].click();", post);

                IWebElement commentButton = driver.FindElement(By.CssSelector("span._aamx svg[aria-label='Comment']"));
                commentButton.Click();

                //Random comment
                int randomIndex = random.Next(0, lines.Length);
                string randomcmt = lines[randomIndex];
                IWebElement cmtInput = driver.FindElement(By.CssSelector("textarea[aria-label='Add a comment…']"));
                cmtInput.SendKeys(randomcmt);

                IWebElement postButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div._am-5 div.x1i10hfl[role='button']")));
                postButton.Click();

                // Wait for the action to complete
                Task.Delay(1000).Wait();

                //Click on the close button
                IWebElement closeButton = driver.FindElement(By.CssSelector("div.x160vmok.x10l6tqk.x1eu8d0j.x1vjfegm div.x1i10hfl.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz.x6s0dn4.xjbqb8w.x1ejq31n.xd10rxx.x1sy0etr.x17r0tee.x1ypdohk.x78zum5.xl56j7k.x1y1aw1k.x1sxyh0.xwib8y2.xurb0ha.xcdnw81[role='button']"));
                closeButton.Click();

                // Wait for the next post to be visible
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
            }
        }

        public void AutoLike(string targetUsername)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            //Select each post
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ScrollDown(js);

            var posts = driver.FindElements(By.CssSelector("div._aagw"));

            foreach (var post in posts)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(post));
                js.ExecuteScript("arguments[0].click();", post);

                //Check if the post already be liked
                bool isnotLiked = driver.FindElements(By.CssSelector("span._aamw svg[aria-label='Like']")).Any();

                if (isnotLiked)
                {
                    driver.FindElement(By.CssSelector("span._aamw svg[aria-label='Like']")).Click();

                    // Wait for the like action to complete
                    Task.Delay(1000).Wait();
                }

                //Click on the close button
                //Click on the close button
                IWebElement closeButton = driver.FindElement(By.CssSelector("div.x160vmok.x10l6tqk.x1eu8d0j.x1vjfegm div.x1i10hfl[role='button']"));

                js.ExecuteScript("arguments[0].click();", closeButton);

                // Wait for the next post to be visible
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));

            }
        }

        public void AutoFollow(string listUser)
        {
            string[] lines = listUser.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            foreach (string line in lines)
            {
                driver.Navigate().GoToUrl($"https://www.instagram.com/{line}/");
                
                var followButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x150jy0e.x1e558r4.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.x1q0g3np.xqjyukv.x6s0dn4.x1oa3qoh.xl56j7k > div._ap3a._aaco._aacw._aad6._aade")));
                string buttonText = followButton.Text;

                if (buttonText == "Follow")
                {
                    {
                        driver.FindElement(By.CssSelector("div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x150jy0e.x1e558r4.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.x1q0g3np.xqjyukv.x6s0dn4.x1oa3qoh.xl56j7k > div._ap3a._aaco._aacw._aad6._aade")).Click();
                        // Wait for the follow action to complete
                        Task.Delay(1000).Wait();
                    }
                }
            }
        }

        public void AutoDownPicCmt(string targetUsername, string downloadFolder)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

            string imagesFolder = Path.Combine(downloadFolder, "ImagesFrom" + targetUsername);
            string commentsFilePath = Path.Combine(downloadFolder, targetUsername + "Comments.txt");
            Directory.CreateDirectory(imagesFolder);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ScrollDown(js);

            var posts = driver.FindElements(By.CssSelector("div._aagw"));

            //Select each post
            foreach (var post in posts)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(post));
                js.ExecuteScript("arguments[0].click();", post);

                // Lấy danh sách các phần tử ảnh trong container
                IList<IWebElement> imageElements = driver.FindElements(By.CssSelector("div._aagv img"));
                foreach (IWebElement imageElement in imageElements)
                {
                    // Lấy đường link của ảnh từ thuộc tính "src"
                    string imageUrl = imageElement.GetAttribute("src");
                    DownloadImage(imageUrl, imagesFolder);
                }

                //Click on the close button
                IWebElement closeButton = driver.FindElement(By.CssSelector("div.x160vmok.x10l6tqk.x1eu8d0j.x1vjfegm div.x1i10hfl[role='button']"));

                js.ExecuteScript("arguments[0].click();", closeButton);

                // Wait for the next post to be visible
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
                //}
            }
                MessageBox.Show("Downloading Complete");
        }
        private void DownloadImage(string imageUrl, string folderPath)
        {
            using (WebClient webClient = new WebClient())
            {
                // Get the image file name from the URL
                string fileName = Path.GetFileName(new Uri(imageUrl).AbsolutePath);
                string filePath = Path.Combine(folderPath, fileName);

                // Download the image
                webClient.DownloadFile(imageUrl, filePath);
            }
        }

        private void SaveCommentToFile(string commentText, string filePath)
        {
            // Save the comment to the specified file
            File.AppendAllText(filePath, commentText + Environment.NewLine);
        }

        private void ScrollDown(IJavaScriptExecutor js)
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Scroll to make all the post visible
            while (true)
            {
                // Store the current height to check if the page is still scrolling
                long currentHeight = (long)js.ExecuteScript("return Math.max( document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight );");

                // Perform scroll down
                actions.SendKeys(OpenQA.Selenium.Keys.End).Perform();

                // Wait for a short time to allow new content to load
                Thread.Sleep(3000);

                // Check if the page has stopped scrolling (height is unchanged)
                long newHeight = (long)js.ExecuteScript("return Math.max( document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight );");
                if (newHeight == currentHeight)
                {
                    break; // Exit the loop if the page has stopped scrolling
                }
            }

            // Wait until the last image is visible
            By lastImageLocator = By.CssSelector("div._aagw:last-child");
            wait.Until(ExpectedConditions.ElementIsVisible(lastImageLocator));
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void Quit()
        {
            driver.Quit();
        }
    }
}
