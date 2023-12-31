using System.Drawing.Drawing2D;

namespace task2_8
{
    public partial class Form1 : Form
    {
        private Point previousPoint;
        private Pen drawingPen;

        int x = 50;
        int y = 50;
        int width = 100;
        int height = 100;
        Color color=Color.Black;
        float size_pen = 2;
        int shape = 0;
        Rectangle rect;
        private bool isDragging = false;
        private Point offset;
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += FreeHand_MouseDown;
            this.MouseMove += FreeHand_MouseMove;
            this.MouseUp += FreeHand_MouseUp;
            this.MouseDown += MovePicture_MouseDown;
            this.MouseMove += MovePicture_MouseMove;
            this.MouseUp += MovePicture_MouseUp;
            this.Paint += new PaintEventHandler(this.Paint_Handler);
            rect = new Rectangle(x, y, width, height);
        }

        private void FreeHand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(Size_comboBox.SelectedItem!=null)
                  this.size_pen = float.Parse(Size_comboBox.SelectedItem.ToString());
                this.drawingPen = new Pen(color, size_pen);
                previousPoint = e.Location;
            }
        }

        private void Paint_Handler(object sender, PaintEventArgs e)
        {
                Graphics g = e.Graphics;
            Pen outline=new Pen(Color.LightBlue, 1);
            outline.StartCap=LineCap.Round;
            outline.EndCap=LineCap.ArrowAnchor;
            
            if (shape == 1)
            {
                g.DrawRectangle(outline, x, y, width, height);
                drawingPen = new Pen(color, size_pen);
                g.DrawRectangle(drawingPen, x, y, width, height);
            }
            else if (shape == 2)
            {
                g.DrawRectangle(outline, x, y, width, height);
                drawingPen = new Pen(color, size_pen);
                g.DrawEllipse(drawingPen, x, y, width, height);
            }
            shape = 0;
        }
        private void FreeHand_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging!=true)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawLine(drawingPen, previousPoint, e.Location);
                    previousPoint = e.Location;
                }
            }
        }

        private void FreeHand_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                previousPoint = Point.Empty;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg";

            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                //Image imageTosave = Form1.Image;

            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog()==DialogResult.OK)
            {
               color = colorDialog.Color;
            }
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.shape = 1;
            using (Graphics g = this.CreateGraphics())
            {
                Pen pen = new Pen(color, size_pen);
                g.DrawRectangle(pen, x, y, width, height);
            }
        }

        private void eclipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 2;
            using (Graphics g = this.CreateGraphics())
            {
                Pen pen = new Pen(color, size_pen);
                g.DrawEllipse(pen, x, y, width, height);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] items_Size = { "1", "2", "3", "4", "6", "8", "10", "12", "14" };
            Size_comboBox.Items.AddRange(items_Size);
        }
        private void MovePicture_MouseDown(object sender,MouseEventArgs e)
        {
            if(e.X>=x&&e.X<=x+width&&e.Y>=y&&e.Y<=e.Y+height)
            {
                isDragging = true;
            }
        }
        private void MovePicture_MouseMove(object sender,MouseEventArgs e)
        {
            if(isDragging)
            {
                x = e.X - width/2;
                y = e.Y - height/2;
            }
        }
        private void MovePicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                rect.Location = new Point(e.X, e.Y);
            }
        }

        private void FormTimerEvents(object sender, EventArgs e)
        {
            rect.X = x;
            rect.Y = y;
            this.Invalidate();
        }
    }
}