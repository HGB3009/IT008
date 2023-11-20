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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            itgbot.Login(usernameTextBox.Text, passwordTextBox.Text);
        }
    }
}
