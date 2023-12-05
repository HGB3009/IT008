using OpenQA.Selenium;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace InstagramInteraction
{
    public partial class Form1 : Form
    {
        instagramBot itgbot;
        bool alreadyLogin = false;
        string loginUsernameNow;
        string loginPasswordNow;
        public Form1()
        {
            InitializeComponent();
            itgbot = new instagramBot();
        }
        private void autoLogin(string username, string password)
        {
            try
            {
                if (!alreadyLogin)
                {
                    if (username != "" && password != "")
                    {
                        loginUsernameNow = username;
                        loginPasswordNow = password;
                        if (!itgbot.Login(loginUsernameNow, loginPasswordNow))
                        {
                            alreadyLogin = false;
                            MessageBox.Show("Thông tin về username và password của account dùng để thực hiện chức năng không đúng!");
                        }
                        else
                            alreadyLogin = true;
                    }
                    else
                    {
                        alreadyLogin = false;
                        MessageBox.Show("Vui lòng nhập thông tin về username và password của account dùng để thực hiện chức năng!");
                    }
                }
                else if (username != loginUsernameNow)
                {
                    if (username != "" && password != "")
                    {
                        itgbot.Logout();
                        Thread.Sleep(3000);
                        loginUsernameNow = username;
                        loginPasswordNow = password;
                        if (!itgbot.Login(loginUsernameNow, loginPasswordNow))
                        {
                            alreadyLogin = false;
                            MessageBox.Show("Thông tin về username và password của account dùng để thực hiện chức năng không đúng!");
                        }
                        else
                            alreadyLogin = true;
                    }
                    else
                    {
                        alreadyLogin = false;
                        MessageBox.Show("Vui lòng nhập thông tin về username và password của account dùng để thực hiện chức năng!");
                    }
                }
            }
            catch (WebDriverTimeoutException)
            {
                alreadyLogin = false;
                MessageBox.Show("Thông tin về username và password của account dùng để thực hiện chức năng không đúng!");
            }
            catch (ElementClickInterceptedException)
            {
                alreadyLogin = false;
                MessageBox.Show("Vui lòng nhập password từ 6 ký tự trở lên!");
            }
        }
        private void autoLikeButton_Click(object sender, EventArgs e)
        {
            if (usernameInteractedInput.Text != "")
            {
                autoLogin(usernameLoginInput.Text, passwordLoginInput.Text);
                if (alreadyLogin)
                {
                    if (itgbot.AutoLike(usernameInteractedInput.Text))
                        MessageBox.Show("Đã like thành công!");
                }

            }
            else
                MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");
        }

        private void autoCmtButton_Click(object sender, EventArgs e)
        {
            if (usernameInteractedInput.Text != "")
            {
                autoLogin(usernameLoginInput.Text, passwordLoginInput.Text);
                if (alreadyLogin)
                {
                    if (cmtInput.Text != "")
                    {
                        if (itgbot.AutoComment(usernameInteractedInput.Text, cmtInput.Text))
                            MessageBox.Show("Đã comment thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập nội dung bạn muốn bình luận!");
                    }
                }

            }
            else
                MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");
        }

        private void autoFollowButton_Click(object sender, EventArgs e)
        {
            if (usernameListInput.Text != "")
            {
                autoLogin(usernameLoginInput.Text, passwordLoginInput.Text);
                if (alreadyLogin)
                {
                    itgbot.AutoFollow(usernameListInput.Text);
                    MessageBox.Show("Đã follow thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng danh sách user bạn muốn follow!");
            }
        }
        private void autoDown_Click(object sender, EventArgs e)
        {
            if (usernameInteractedInput.Text != "")
            {
                autoLogin(usernameLoginInput.Text, passwordLoginInput.Text);
                if (alreadyLogin)
                {
                    string downloadFolder = GetDownloadFolder();
                    itgbot.AutoDownPicCmt(usernameInteractedInput.Text, downloadFolder);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");
        }
        private static string GetDownloadFolder()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Chọn thư mục để lưu trữ ảnh và bình luận",
                ShowNewFolderButton = true
            };

            //Check if the selectedpath is choosen
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            else
            {
                //Return the directory of the debug folder in this project folder
                return Environment.CurrentDirectory;
            }
        }

        private void heartRainButton_Click(object sender, EventArgs e)
        {
            if (accountListInput.Text != "")
            {
                if (usernameInteractedInput.Text != "")
                {
                    string[] lines = accountListInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    List<string> accountList = new List<string>(lines);

                    int numberOfAccountsToUse = Convert.ToInt32(numberOfHeart.Value);
                    if (numberOfAccountsToUse > 0)
                    {
                        List<string> selectedAccounts = new List<string>();
                        Random random = new Random();

                        for (int i = 0; i < numberOfAccountsToUse && i < accountList.Count; i++)
                        {
                            int randomIndex = random.Next(accountList.Count);
                            selectedAccounts.Add(accountList[randomIndex]);
                            accountList.RemoveAt(randomIndex);
                        }

                        foreach (var selectedAccount in selectedAccounts)
                        {
                            string[] parts = selectedAccount.Split(',');
                            string username = parts[0];
                            string password = parts[1];

                            autoLogin(username, password);

                            if (alreadyLogin)
                            {
                                itgbot.AutoLike(usernameInteractedInput.Text);
                            }
                        }

                        MessageBox.Show($"Đã thực hiện chức năng thành công với {numberOfAccountsToUse} tài khoản ngẫu nhiên!");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số lượng tài khoản muốn sử dụng và đảm bảo nó là một số dương!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng danh sách account bạn dùng để bão tim!");
            }
        }
    }
}