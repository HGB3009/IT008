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
                    foreach (var line in lines)
                    {
                        string[] parts = line.Split(',');
                        string username = parts[0];
                        string password = parts[1];
                        autoLogin(username, password);
                        if (alreadyLogin)
                        {                        
                            itgbot.AutoLike(usernameInteractedInput.Text);
                        
                        }
                    }
                    MessageBox.Show("Đã like thành công!");
                }
                else
                    MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");
            }
            else
            {
                MessageBox.Show("Vui lòng danh sách account bạn dùng để bão tim!");
            }
        }
    }

}