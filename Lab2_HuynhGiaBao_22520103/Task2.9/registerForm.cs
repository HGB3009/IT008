using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2._9
{
    public partial class registerForm : Form
    {
        public bool IsRegister { get; private set; } = false;
        private const string UserFileName = "user.txt";
        private const string Key = "0123456789abcdef";
        public registerForm()
        {
            InitializeComponent();
        }


        private void SaveUserCredentials(string username, string password)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(UserFileName))
                {
                    string encryptedPassword = EncryptString(password, Key);
                    sw.WriteLine($"{username}:{encryptedPassword}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user credentials: {ex.Message}");
            }
        }

        private static string EncryptString(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == repasswordTextBox.Text)
            {
                SaveUserCredentials(usernameTextBox.Text, passwordTextBox.Text);
                MessageBox.Show("Register success!");
                IsRegister = true;
                this.Close();
            }
            else
                MessageBox.Show("Password is different from Repassword! Please retype");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
