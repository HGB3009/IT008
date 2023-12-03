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
            
        }
        private void autoLogout()
        {
            itgbot.Logout();
        }
        private void autoLikeButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            itgbot.AutoLike(usernameInteractedInput.Text);
        }

        private void autoCmtButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            string[] lines = cmtInput.Lines;

            if (lines.Length > 0)
            {

                itgbot.AutoComment(usernameInteractedInput.Text, cmtInput.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập nội dung bạn muốn bình luận!");
            }
        }

        private void autoFollowButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            itgbot.AutoFollow(usernameListInput.Text);
        }
        private void autoDown_Click(object sender, EventArgs e)
        {
            autoLogin();
            string downloadFolder = GetDownloadFolder();
            itgbot.AutoDownPicCmt(usernameInteractedInput.Text, downloadFolder);
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
                //return a 
                return Environment.CurrentDirectory;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoLogin();
            autoLogout();
        }
    }
}