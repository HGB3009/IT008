namespace Task2._8
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
            button1 = new Button();
            buttonColor = new Button();
            saveButton = new Button();
            selectedShape = new ComboBox();
            colorDialog1 = new ColorDialog();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(513, 365);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Paint";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonColor
            // 
            buttonColor.Location = new Point(199, 363);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(138, 29);
            buttonColor.TabIndex = 1;
            buttonColor.Text = "Choose Color";
            buttonColor.UseVisualStyleBackColor = true;
            buttonColor.Click += buttonColor_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(648, 365);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // selectedShape
            // 
            selectedShape.FormattingEnabled = true;
            selectedShape.Location = new Point(12, 364);
            selectedShape.Name = "selectedShape";
            selectedShape.Size = new Size(151, 28);
            selectedShape.TabIndex = 3;
            selectedShape.SelectedIndexChanged += selectedShape_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(359, 365);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(119, 27);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDown1);
            Controls.Add(selectedShape);
            Controls.Add(saveButton);
            Controls.Add(buttonColor);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button buttonColor;
        private Button saveButton;
        private ComboBox selectedShape;
        private ColorDialog colorDialog1;
        private NumericUpDown numericUpDown1;
    }
}