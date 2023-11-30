namespace InstagramInteraction
{
    public partial class Form1 : Form
    {
        instagramBot itgbot;
        public Form1()
        {
            InitializeComponent();
            itgbot = new instagramBot();
        }
        private void autoLogin()
        {
            itgbot.Login(usernameLoginInput.Text, passwordLoginInput.Text);
        }

        private void autoDown_Click(object sender, EventArgs e)
        {

        }

        private void autoLikeButton_Click(object sender, EventArgs e)
        {
            autoLogin();
            itgbot.AutoLike(usernameInteractedInput.Text);
        }
    }
}