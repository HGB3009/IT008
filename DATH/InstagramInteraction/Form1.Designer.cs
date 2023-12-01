namespace InstagramInteraction
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox6 = new GroupBox();
            cmtInput = new RichTextBox();
            autoCmtButton = new Button();
            groupBox5 = new GroupBox();
            usernameListInput = new RichTextBox();
            autoFollowButton = new Button();
            autoLikeButton = new Button();
            groupBox4 = new GroupBox();
            usernameInteractedInput = new TextBox();
            groupBox3 = new GroupBox();
            usernameLoginInput = new TextBox();
            passwordLoginInput = new TextBox();
            autoDownloadButton = new Button();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(782, 197);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bão Tim";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(autoLikeButton);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(autoDownloadButton);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(782, 756);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Các chức năng khác";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(cmtInput);
            groupBox6.Controls.Add(autoCmtButton);
            groupBox6.Dock = DockStyle.Bottom;
            groupBox6.Location = new Point(3, 281);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(776, 238);
            groupBox6.TabIndex = 16;
            groupBox6.TabStop = false;
            groupBox6.Text = "Nhập các câu bình luận:";
            // 
            // cmtInput
            // 
            cmtInput.Dock = DockStyle.Left;
            cmtInput.Location = new Point(3, 26);
            cmtInput.Name = "cmtInput";
            cmtInput.Size = new Size(501, 209);
            cmtInput.TabIndex = 15;
            cmtInput.Text = "";
            // 
            // autoCmtButton
            // 
            autoCmtButton.Location = new Point(558, 103);
            autoCmtButton.Name = "autoCmtButton";
            autoCmtButton.Size = new Size(153, 55);
            autoCmtButton.TabIndex = 14;
            autoCmtButton.Text = "Tự động bình luận";
            autoCmtButton.UseVisualStyleBackColor = true;
            autoCmtButton.Click += autoCmtButton_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(usernameListInput);
            groupBox5.Controls.Add(autoFollowButton);
            groupBox5.Dock = DockStyle.Bottom;
            groupBox5.Location = new Point(3, 519);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(776, 234);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Nhập danh sách các user cần follow:";
            // 
            // usernameListInput
            // 
            usernameListInput.Dock = DockStyle.Left;
            usernameListInput.Location = new Point(3, 26);
            usernameListInput.Name = "usernameListInput";
            usernameListInput.Size = new Size(501, 205);
            usernameListInput.TabIndex = 16;
            usernameListInput.Text = "";
            // 
            // autoFollowButton
            // 
            autoFollowButton.Location = new Point(558, 103);
            autoFollowButton.Name = "autoFollowButton";
            autoFollowButton.Size = new Size(153, 55);
            autoFollowButton.TabIndex = 15;
            autoFollowButton.Text = "Tự động follow";
            autoFollowButton.UseVisualStyleBackColor = true;
            autoFollowButton.Click += autoFollowButton_Click;
            // 
            // autoLikeButton
            // 
            autoLikeButton.Location = new Point(484, 220);
            autoLikeButton.Name = "autoLikeButton";
            autoLikeButton.Size = new Size(153, 55);
            autoLikeButton.TabIndex = 13;
            autoLikeButton.Text = "Tự động like";
            autoLikeButton.UseVisualStyleBackColor = true;
            autoLikeButton.Click += autoLikeButton_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(usernameInteractedInput);
            groupBox4.Location = new Point(412, 29);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(364, 175);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nhập username cần tương tác:";
            // 
            // usernameInteractedInput
            // 
            usernameInteractedInput.Location = new Point(33, 76);
            usernameInteractedInput.Name = "usernameInteractedInput";
            usernameInteractedInput.PlaceholderText = "Username";
            usernameInteractedInput.Size = new Size(298, 30);
            usernameInteractedInput.TabIndex = 11;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(usernameLoginInput);
            groupBox3.Controls.Add(passwordLoginInput);
            groupBox3.Location = new Point(0, 29);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(406, 175);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nhập account dùng để thực hiện chức năng";
            // 
            // usernameLoginInput
            // 
            usernameLoginInput.Location = new Point(39, 57);
            usernameLoginInput.Name = "usernameLoginInput";
            usernameLoginInput.PlaceholderText = "Phone number, username or email";
            usernameLoginInput.Size = new Size(298, 30);
            usernameLoginInput.TabIndex = 10;
            // 
            // passwordLoginInput
            // 
            passwordLoginInput.Location = new Point(39, 109);
            passwordLoginInput.Name = "passwordLoginInput";
            passwordLoginInput.PasswordChar = '*';
            passwordLoginInput.PlaceholderText = "Password";
            passwordLoginInput.Size = new Size(298, 30);
            passwordLoginInput.TabIndex = 9;
            // 
            // autoDownloadButton
            // 
            autoDownloadButton.Location = new Point(151, 220);
            autoDownloadButton.Name = "autoDownloadButton";
            autoDownloadButton.Size = new Size(153, 55);
            autoDownloadButton.TabIndex = 3;
            autoDownloadButton.Text = "Tự động cào tất cả ảnh/bình luận";
            autoDownloadButton.UseVisualStyleBackColor = true;
            autoDownloadButton.Click += autoDown_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 953);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Instagram Interaction Tool";
            groupBox2.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button autoDownloadButton;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private TextBox usernameInteractedInput;
        private TextBox usernameLoginInput;
        private TextBox passwordLoginInput;
        private Button autoCmtButton;
        private Button autoLikeButton;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private Button autoFollowButton;
        private RichTextBox cmtInput;
        private RichTextBox usernameListInput;
    }
}