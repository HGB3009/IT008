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
        private void autoLogin()
        {
            try
            {
                if (usernameLoginInput.Text != "" && passwordLoginInput.Text != "")
                    if (!alreadyLogin)
                    {
                        loginUsernameNow = usernameLoginInput.Text;
                        loginPasswordNow = passwordLoginInput.Text;
                        itgbot.Login(loginUsernameNow, loginPasswordNow);
                        alreadyLogin = true;
                    }
                    else
                    {
                        if (usernameLoginInput.Text != loginUsernameNow)
                        {
                            itgbot.Logout();
                            loginUsernameNow = usernameLoginInput.Text;
                            loginPasswordNow = passwordLoginInput.Text;
                            itgbot.Login(loginUsernameNow, loginPasswordNow);
                        }
                    }
                else
                    MessageBox.Show("Vui lòng nhập thông tin về username và password của account dùng để thực hiện chức năng!");
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Thông tin về username và password của account dùng để thực hiện chức năng không đúng!");
            }
            catch (ElementClickInterceptedException)
            {
                MessageBox.Show("Vui lòng nhập password từ 6 ký tự trở lên!");
            }
            
        }
        private void autoLikeButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            if (usernameInteractedInput.Text != "")
            {
                itgbot.AutoLike(usernameInteractedInput.Text);
                MessageBox.Show("Đã like thành công!");
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");
        }

        private void autoCmtButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            if (usernameInteractedInput.Text != "")
            {
                if (cmtInput.Text != "")
                {
                    itgbot.AutoComment(usernameInteractedInput.Text, cmtInput.Text);
                    MessageBox.Show("Đã comment thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập nội dung bạn muốn bình luận!");
                }
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin về username cần tương tác!");

        }

        private void autoFollowButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            if (usernameListInput.Text != "")
            {
                itgbot.AutoFollow(usernameListInput.Text);
                MessageBox.Show("Đã follow thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng danh sách user bạn muốn follow!");
            }
        }
        private void autoDown_Click(object sender, EventArgs e)
        {
            autoLogin();
            if (usernameInteractedInput.Text != "")
            {
                string downloadFolder = GetDownloadFolder();
                itgbot.AutoDownPicCmt(usernameInteractedInput.Text, downloadFolder);
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
            MessageBox.Show(usernameLoginInput.Text);
        }
    }

}