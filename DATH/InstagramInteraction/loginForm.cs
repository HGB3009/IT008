using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramInteraction
{
    public partial class loginForm : Form
    {
        public event EventHandler SuccessfulLogin;
        private instagramBot itgbot;
        public loginForm()
        {
            InitializeComponent();
            itgbot = new instagramBot();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (itgbot.Login(usernameTextBox.Text, passwordTextBox.Text))
            {
                this.SuccessfulLogin?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Login success!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
            
        }
    }
}
