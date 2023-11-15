namespace Task2._9
{
    partial class registerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginButton = new Button();
            registerButton = new Button();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            repasswordTextBox = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.Salmon;
            loginButton.Location = new Point(317, 397);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(120, 41);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Salmon;
            registerButton.Location = new Point(317, 287);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(120, 41);
            registerButton.TabIndex = 1;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(296, 126);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(295, 27);
            usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(296, 182);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(295, 27);
            passwordTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Highlight;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 69);
            label1.TabIndex = 4;
            label1.Text = "REGISTER";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(108, 115);
            label2.Name = "label2";
            label2.Size = new Size(155, 38);
            label2.TabIndex = 5;
            label2.Text = "UserName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(108, 171);
            label3.Name = "label3";
            label3.Size = new Size(148, 38);
            label3.TabIndex = 6;
            label3.Text = "PassWord";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(296, 354);
            label4.Name = "label4";
            label4.Size = new Size(176, 40);
            label4.TabIndex = 7;
            label4.Text = "already have an account?\r\nSign in here";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // repasswordTextBox
            // 
            repasswordTextBox.Location = new Point(296, 239);
            repasswordTextBox.Name = "repasswordTextBox";
            repasswordTextBox.PasswordChar = '*';
            repasswordTextBox.Size = new Size(295, 27);
            repasswordTextBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(84, 228);
            label5.Name = "label5";
            label5.Size = new Size(192, 38);
            label5.TabIndex = 9;
            label5.Text = "Re-PassWord";
            // 
            // registerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(repasswordTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(registerButton);
            Controls.Add(loginButton);
            Name = "registerForm";
            Text = "registerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private Button registerButton;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox repasswordTextBox;
        private Label label5;
    }
}