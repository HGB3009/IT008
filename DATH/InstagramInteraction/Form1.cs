namespace InstagramInteraction
{
    public partial class Form1 : Form
    {
        private bool isLoggedIn = false;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
        private void ShowLoginForm()
        {
            var loginForm = new loginForm();
            loginForm.SuccessfulLogin += LoginForm_SuccessfulLogin;
            loginForm.ShowDialog();

            if (!isLoggedIn)
            {
                Close();
            }
        }
        private void LoginForm_SuccessfulLogin(object sender, EventArgs e)
        {
            isLoggedIn = true;
        }
    }
}