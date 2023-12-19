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
            groupBox3 = new GroupBox();
            usernameLoginInput = new TextBox();
            passwordLoginInput = new TextBox();
            groupBox4 = new GroupBox();
            usernameInteractedInput = new TextBox();
            groupBox2 = new GroupBox();
            groupBox7 = new GroupBox();
            endTimePicker = new DateTimePicker();
            startTimePicker = new DateTimePicker();
            label3 = new Label();
            userLiketxtButton = new Button();
            label2 = new Label();
            label1 = new Label();
            heartRainButton = new Button();
            numberOfHeart = new NumericUpDown();
            accountListInput = new RichTextBox();
            groupBox6 = new GroupBox();
            cmttxtButton = new Button();
            cmtInput = new RichTextBox();
            autoCmtButton = new Button();
            groupBox5 = new GroupBox();
            followtxtButton = new Button();
            usernameListInput = new RichTextBox();
            autoFollowButton = new Button();
            autoLikeButton = new Button();
            autoDownloadButton = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numberOfHeart).BeginInit();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(782, 197);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập thông tin";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(usernameLoginInput);
            groupBox3.Controls.Add(passwordLoginInput);
            groupBox3.Location = new Point(3, 26);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(406, 168);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nhập account dùng để thực hiện chức năng";
            // 
            // usernameLoginInput
            // 
            usernameLoginInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usernameLoginInput.Location = new Point(39, 57);
            usernameLoginInput.Name = "usernameLoginInput";
            usernameLoginInput.PlaceholderText = "Phone number, username or email";
            usernameLoginInput.Size = new Size(298, 30);
            usernameLoginInput.TabIndex = 10;
            // 
            // passwordLoginInput
            // 
            passwordLoginInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            passwordLoginInput.Location = new Point(39, 109);
            passwordLoginInput.Name = "passwordLoginInput";
            passwordLoginInput.PasswordChar = '*';
            passwordLoginInput.PlaceholderText = "Password";
            passwordLoginInput.Size = new Size(298, 30);
            passwordLoginInput.TabIndex = 9;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(usernameInteractedInput);
            groupBox4.Location = new Point(415, 26);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(364, 168);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nhập username cần tương tác:";
            // 
            // usernameInteractedInput
            // 
            usernameInteractedInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usernameInteractedInput.Location = new Point(33, 76);
            usernameInteractedInput.Name = "usernameInteractedInput";
            usernameInteractedInput.PlaceholderText = "Username";
            usernameInteractedInput.Size = new Size(298, 30);
            usernameInteractedInput.TabIndex = 11;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox7);
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(autoLikeButton);
            groupBox2.Controls.Add(autoDownloadButton);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(782, 756);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Các chức năng khác";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(endTimePicker);
            groupBox7.Controls.Add(startTimePicker);
            groupBox7.Controls.Add(label3);
            groupBox7.Controls.Add(userLiketxtButton);
            groupBox7.Controls.Add(label2);
            groupBox7.Controls.Add(label1);
            groupBox7.Controls.Add(heartRainButton);
            groupBox7.Controls.Add(numberOfHeart);
            groupBox7.Controls.Add(accountListInput);
            groupBox7.Dock = DockStyle.Bottom;
            groupBox7.Location = new Point(3, 91);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(776, 246);
            groupBox7.TabIndex = 17;
            groupBox7.TabStop = false;
            groupBox7.Text = "Bão tim";
            // 
            // endTimePicker
            // 
            endTimePicker.Format = DateTimePickerFormat.Time;
            endTimePicker.Location = new Point(632, 127);
            endTimePicker.Name = "endTimePicker";
            endTimePicker.Size = new Size(141, 30);
            endTimePicker.TabIndex = 25;
            // 
            // startTimePicker
            // 
            startTimePicker.Format = DateTimePickerFormat.Time;
            startTimePicker.Location = new Point(632, 91);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.Size = new Size(141, 30);
            startTimePicker.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(479, 127);
            label3.Name = "label3";
            label3.Size = new Size(153, 23);
            label3.TabIndex = 23;
            label3.Text = "Thời gian kết thúc:";
            // 
            // userLiketxtButton
            // 
            userLiketxtButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userLiketxtButton.Location = new Point(483, 171);
            userLiketxtButton.Name = "userLiketxtButton";
            userLiketxtButton.Size = new Size(153, 55);
            userLiketxtButton.TabIndex = 16;
            userLiketxtButton.Text = "Connect txt";
            userLiketxtButton.UseVisualStyleBackColor = true;
            userLiketxtButton.Click += userLiketxtButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(483, 97);
            label2.Name = "label2";
            label2.Size = new Size(149, 23);
            label2.TabIndex = 22;
            label2.Text = "Thời gian bắt đầu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(490, 47);
            label1.Name = "label1";
            label1.Size = new Size(108, 23);
            label1.TabIndex = 21;
            label1.Text = "Nhập số tim:";
            // 
            // heartRainButton
            // 
            heartRainButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            heartRainButton.Location = new Point(638, 171);
            heartRainButton.Name = "heartRainButton";
            heartRainButton.Size = new Size(125, 55);
            heartRainButton.TabIndex = 18;
            heartRainButton.Text = "Bão tim";
            heartRainButton.UseVisualStyleBackColor = true;
            heartRainButton.Click += heartRainButton_Click;
            // 
            // numberOfHeart
            // 
            numberOfHeart.Location = new Point(623, 45);
            numberOfHeart.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numberOfHeart.Name = "numberOfHeart";
            numberOfHeart.Size = new Size(150, 30);
            numberOfHeart.TabIndex = 1;
            // 
            // accountListInput
            // 
            accountListInput.Dock = DockStyle.Left;
            accountListInput.Location = new Point(3, 26);
            accountListInput.Name = "accountListInput";
            accountListInput.Size = new Size(474, 217);
            accountListInput.TabIndex = 0;
            accountListInput.Text = "";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(cmttxtButton);
            groupBox6.Controls.Add(cmtInput);
            groupBox6.Controls.Add(autoCmtButton);
            groupBox6.Dock = DockStyle.Bottom;
            groupBox6.Location = new Point(3, 337);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(776, 207);
            groupBox6.TabIndex = 16;
            groupBox6.TabStop = false;
            groupBox6.Text = "Nhập các câu bình luận:";
            // 
            // cmttxtButton
            // 
            cmttxtButton.Location = new Point(549, 127);
            cmttxtButton.Name = "cmttxtButton";
            cmttxtButton.Size = new Size(153, 55);
            cmttxtButton.TabIndex = 17;
            cmttxtButton.Text = "Connect txt";
            cmttxtButton.UseVisualStyleBackColor = true;
            cmttxtButton.Click += cmttxtButton_Click;
            // 
            // cmtInput
            // 
            cmtInput.Dock = DockStyle.Left;
            cmtInput.Location = new Point(3, 26);
            cmtInput.Name = "cmtInput";
            cmtInput.Size = new Size(474, 178);
            cmtInput.TabIndex = 15;
            cmtInput.Text = "";
            // 
            // autoCmtButton
            // 
            autoCmtButton.Location = new Point(549, 54);
            autoCmtButton.Name = "autoCmtButton";
            autoCmtButton.Size = new Size(153, 55);
            autoCmtButton.TabIndex = 14;
            autoCmtButton.Text = "Tự động bình luận";
            autoCmtButton.UseVisualStyleBackColor = true;
            autoCmtButton.Click += autoCmtButton_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(followtxtButton);
            groupBox5.Controls.Add(usernameListInput);
            groupBox5.Controls.Add(autoFollowButton);
            groupBox5.Dock = DockStyle.Bottom;
            groupBox5.Location = new Point(3, 544);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(776, 209);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Nhập danh sách các user cần follow:";
            // 
            // followtxtButton
            // 
            followtxtButton.Location = new Point(549, 131);
            followtxtButton.Name = "followtxtButton";
            followtxtButton.Size = new Size(153, 55);
            followtxtButton.TabIndex = 18;
            followtxtButton.Text = "Connect txt";
            followtxtButton.UseVisualStyleBackColor = true;
            followtxtButton.Click += followtxtButton_Click;
            // 
            // usernameListInput
            // 
            usernameListInput.Dock = DockStyle.Left;
            usernameListInput.Location = new Point(3, 26);
            usernameListInput.Name = "usernameListInput";
            usernameListInput.Size = new Size(474, 180);
            usernameListInput.TabIndex = 16;
            usernameListInput.Text = "";
            // 
            // autoFollowButton
            // 
            autoFollowButton.Location = new Point(549, 52);
            autoFollowButton.Name = "autoFollowButton";
            autoFollowButton.Size = new Size(153, 55);
            autoFollowButton.TabIndex = 15;
            autoFollowButton.Text = "Tự động follow";
            autoFollowButton.UseVisualStyleBackColor = true;
            autoFollowButton.Click += autoFollowButton_Click;
            // 
            // autoLikeButton
            // 
            autoLikeButton.Location = new Point(448, 29);
            autoLikeButton.Name = "autoLikeButton";
            autoLikeButton.Size = new Size(153, 55);
            autoLikeButton.TabIndex = 13;
            autoLikeButton.Text = "Tự động like";
            autoLikeButton.UseVisualStyleBackColor = true;
            autoLikeButton.Click += autoLikeButton_Click;
            // 
            // autoDownloadButton
            // 
            autoDownloadButton.Location = new Point(148, 29);
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
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Instagram Interaction Tool";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numberOfHeart).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
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
        private GroupBox groupBox7;
        private NumericUpDown numberOfHeart;
        private RichTextBox richTextBox1;
        private Button heartRainButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private RichTextBox userList;
        private RichTextBox accountListInput;
        private Button cmttxtButton;
        private Button userLiketxtButton;
        private Button followtxtButton;
        private DateTimePicker endTimePicker;
        private DateTimePicker startTimePicker;
    }
}