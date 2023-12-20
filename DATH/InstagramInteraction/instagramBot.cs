using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Debugger;
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

        public bool Login(string username, string password)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));


                IWebElement usernameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
                IWebElement passwordInput = driver.FindElement(By.Name("password"));
                IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

                usernameInput.SendKeys(username);
                passwordInput.SendKeys(password);
                loginButton.Click();
                if (driver.FindElement(By.ClassName("_ab2z")).Displayed)
                    return false;
                return true;
            }
            catch (NoSuchElementException)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                try
                {
                    IWebElement notNowButton1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Not now']")));
                    notNowButton1.Click();
                } 
                
                catch (NoSuchElementException)
                {
                    
                }
                try
                {
                    IWebElement notNowButton2 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button._a9--._ap36._a9_1")));
                    notNowButton2.Click();
                }
                catch (WebDriverTimeoutException)
                {
                    return true;
                }
                return true;
            }
        }
        public void Logout()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement settingButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.x9f619.xxk0z11.xii2z7h.x11xpdln.x19c4wfv.xvy4d1p > svg[aria-label='Settings']")));
                settingButton.Click();

                IWebElement LogoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class, 'x9f619') and contains(@class, 'xjbqb8w') and contains(@class, 'x78zum5') and contains(@class, 'x168nmei') and contains(@class, 'x13lgxp2') and contains(@class, 'x5pf9jr') and contains(@class, 'xo71vjh') and contains(@class, 'x1uhb9sk') and contains(@class, 'x1plvlek') and contains(@class, 'xryxfnj') and contains(@class, 'x1iyjqo2') and contains(@class, 'x2lwn1j') and contains(@class, 'xeuugli') and contains(@class, 'xdt5ytf') and contains(@class, 'xqjyukv') and contains(@class, 'x1cy8zhl') and contains(@class, 'x1oa3qoh') and contains(@class, 'x1nhvcw1')]//span[text()='Log out']")));
                js.ExecuteScript("arguments[0].click();", LogoutButton);

                IWebElement loginbutton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button._a9--._ap36._a9_1")));
                loginbutton.Click();
            }
            catch (StaleElementReferenceException)
            {

            }

        }

        public bool AutoComment(string targetUsername, string comment)
        {
            try
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

                    try
                    {
                        IWebElement commentButton = driver.FindElement(By.CssSelector("span._aamx svg[aria-label='Comment']"));
                        commentButton.Click();
                    }
                    catch (NoSuchElementException)
                    {
                        continue;
                    }

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
                    IWebElement closeButton = driver.FindElement(By.CssSelector("div.x160vmok.x10l6tqk.x1eu8d0j.x1vjfegm div.x1i10hfl[role='button']"));

                    js.ExecuteScript("arguments[0].click();", closeButton);

                    // Wait for the next post to be visible
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
                }
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                MessageBox.Show("User có thể bị xóa ,không đăng ảnh hoặc không public ảnh");
                return false;
            }
        }

        public bool AutoLike(string targetUsername)
        {
            try {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

                driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

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
                        IWebElement likeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span._aamw svg[aria-label='Like']")));
                        likeButton.Click();
                        // Wait for the like action to complete
                        Task.Delay(1000).Wait();
                    }

                    //Click on the close button
                    IWebElement closeButton = driver.FindElement(By.CssSelector("div.x160vmok.x10l6tqk.x1eu8d0j.x1vjfegm div.x1i10hfl[role='button']"));

                    js.ExecuteScript("arguments[0].click();", closeButton);

                    // Wait for the next post to be visible
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
                }
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                MessageBox.Show("User có thể bị xóa ,không đăng ảnh hoặc không public ảnh");
                return false;
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
            try 
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl($"https://www.instagram.com/{targetUsername}/");

                string imagesFolder = Path.Combine(downloadFolder, "ImagesFrom" + targetUsername);
                string commentsFilePath = Path.Combine(downloadFolder, targetUsername + "Comments.txt");
                Directory.CreateDirectory(imagesFolder);
                string postsFolder = Path.Combine(downloadFolder, "PostsFrom" + targetUsername);
                Directory.CreateDirectory(postsFolder);

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                ScrollDown(js);

                //Download Images
                IList<IWebElement> imageElements = driver.FindElements(By.XPath("//div[@class='_aagv']//img\r\n"));
                foreach (IWebElement imageElement in imageElements)
                {
                    string imageUrl = imageElement.GetAttribute("src");
                    DownloadImage(imageUrl, imagesFolder);
                }

                var posts = driver.FindElements(By.CssSelector("div._aagw"));


                //Download CMT
                int postIndex = 1;
                //Select each post
                foreach (var post in posts)
                {
                    string postFilePath = Path.Combine(postsFolder, $"Post{postIndex}.txt");

                    wait.Until(ExpectedConditions.ElementToBeClickable(post));
                    js.ExecuteScript("arguments[0].click();", post);

                    try
                    {
                        // Wait for comments to load
                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span._ap3a._aaco._aacu._aacx._aad7._aade")));

                        // Scroll down to load more comments
                        CmtScrollDown(js);

                        //Get all the comment
                        IList<IWebElement> comments = driver.FindElements(By.CssSelector("h1._ap3a._aaco._aacu._aacx._aad7._aade, span._ap3a._aaco._aacu._aacx._aad7._aade"));
                        //Get the username who cmt
                        IList<IWebElement> usernameElement = driver.FindElements(By.CssSelector("a.x1i10hfl.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.xdl72j9.x2lah0s.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x2lwn1j.xeuugli.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1q0g3np.x1lku1pv.x1a2a7pz.x6s0dn4.xjyslct.x1ejq31n.xd10rxx.x1sy0etr.x17r0tee.x9f619.x1ypdohk.x1f6kntn.xwhw2v2.xl56j7k.x17ydfre.x2b8uid.xlyipyv.x87ps6o.x14atkfc.xcdnw81.x1i0vuye.xjbqb8w.xm3z3ea.x1x8b98j.x131883w.x16mih1h.x972fbf.xcfux6l.x1qhh985.xm0m39n.xt0psk2.xt7dq6l.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x1n5bzlp.xqnirrm.xj34u2y.x568u83"));

                        //Download the comment
                        for (int i = 0; i < comments.Count; i++)
                        {
                            string addingcmt = usernameElement[i].Text + " : " + comments[i].Text;
                            SaveCommentToFile(addingcmt, postFilePath);
                        }
                    }

                    catch(WebDriverTimeoutException)
                    {
                    }

                //Click on the close button
                    IWebElement closeButton = driver.FindElement(By.CssSelector("div.x160vmok.x10l6tqk.x1eu8d0j.x1vjfegm div.x1i10hfl[role='button']"));

                    js.ExecuteScript("arguments[0].click();", closeButton);

                    // Wait for the next post to be visible
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div._aagw")));
                    postIndex++;
                }
                MessageBox.Show("Đã tải ảnh thành công và comment thành công");

            }
            catch (WebDriverTimeoutException)
            {
                MessageBox.Show("User có thể bị xóa ,không đăng ảnh hoặc không public ảnh");
            }
        }
        private void SaveCommentToFile(string comments, string postFilePath)
        {
            using (StreamWriter writer = new StreamWriter(postFilePath, true))
            {
                writer.WriteLine(comments);
            }
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
                Thread.Sleep(2000);

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
        private void CmtScrollDown(IJavaScriptExecutor js)
        {
            try
            {
                Actions actions = new Actions(driver);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                //Scroll to make all the post visible
                while (true)
                {
                   

                    Thread.Sleep(1000);
                    // Perform scroll down
                    actions.SendKeys(OpenQA.Selenium.Keys.End).Perform();

                    // Wait for a short time to allow new content to load
                    Thread.Sleep(1000);

                    IWebElement loadButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("svg[aria-label='Load more comments']")));
                    loadButton.Click();

                }
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (WebDriverTimeoutException) { return; }
            
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
