using System.Windows.Forms;

namespace Task2._9
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
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

        private void LoginForm_RegisterSuccessful(object sender, EventArgs e)
        {
            
            Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSaveChanges())
            {
                richTextBox1.Text = string.Empty;
                currentFilePath = string.Empty;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSaveChanges())
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    richTextBox1.Text = File.ReadAllText(currentFilePath);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void SaveToFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            File.WriteAllText(currentFilePath, richTextBox1.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckSaveChanges())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private bool CheckSaveChanges()
        {
            if (richTextBox1.Modified)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveToFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }
        private void loggoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLoggedIn = false;
            richTextBox1.Text = string.Empty;
            currentFilePath = string.Empty;
            ShowLoginForm();
        }

    }
}

