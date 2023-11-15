using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Task2._9
{
    public partial class loginForm : Form
    {
        public event EventHandler SuccessfulLogin;
        public event EventHandler RegisterSuccessfulLG;
        private bool isRegister = false;
        private const string UserFileName = "user.txt";
        private const string Key = "0123456789abcdef";
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Check login credentials (you need to implement this part)
            if (IsValidLogin(usernameTextBox.Text, passwordTextBox.Text))
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

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerForm register = new registerForm();
            register.Owner = this;
            register.FormClosed += (s, args) =>
            {
                if (register.IsRegister)
                {
                    this.SuccessfulLogin?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            };
            register.ShowDialog();
        }

        private void RegisterForm_RegisterSuccessful(object sender, EventArgs e)
        {
            isRegister = true;
        }

        private bool IsValidLogin(string username, string password)
        {
            if (File.Exists(UserFileName))
            {
                using (StreamReader sr = new StreamReader(UserFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string storedUsername = parts[0];
                            string storedEncryptedPassword = parts[1];

                            if (storedUsername == username)
                            {
                                string decryptedPassword = DecryptString(storedEncryptedPassword, Key);
                                if (password == decryptedPassword)
                                    return true;
                            }
                        }
                    }
                }
                return false;

            }
            return false;
        }


        private static string DecryptString(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
