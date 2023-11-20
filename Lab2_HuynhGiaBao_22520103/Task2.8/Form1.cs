using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task2._8
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing = false;
        private List<Shape> shapes = new List<Shape>();
        private Bitmap tempBitmap; // Thêm biến Bitmap để lưu hình vẽ tạm thời

        private enum DrawingTool
        {
            Freehand,
            Rectangle,
            Ellipse
        }

        private DrawingTool currentTool = DrawingTool.Freehand;
        private Color currentColor = Color.Black;
        private float currentLineWidth = 2.0f;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            InitializeComboBox();
            this.Load += Form1_Load;
            tempBitmap = new Bitmap(this.Width, this.Height); // Khởi tạo tempBitmap
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
        }

        private void InitializeComboBox()
        {
            selectedShape.Items.Add("Free Draw");
            selectedShape.Items.Add("Rectangle");
            selectedShape.Items.Add("Ellipse");
            selectedShape.SelectedIndex = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Shape shape in shapes)
            {
                shape.Draw(g);
            }

            // Hiển thị hình vẽ tạm thời trên tempBitmap
            g.DrawImage(tempBitmap, 0, 0);

            if (isDrawing)
            {
                // Vẽ tự do
                g.DrawLine(new Pen(currentColor, currentLineWidth), startPoint, endPoint);
            }
        }

            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                startPoint = e.Location;
                isDrawing = true;
            }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(tempBitmap))
                {
                    g.Clear(Color.White);
                    foreach (Shape shape in shapes)
                    {
                        shape.Draw(g);
                    }

                    if (currentTool == DrawingTool.Freehand)
                    {
                        g.DrawLine(new Pen(currentColor, currentLineWidth), startPoint, endPoint);
                    }
                    else
                    {
                        Shape tempShape = CreateShape();
                        tempShape.Draw(g);
                    }
                }

                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;

            Shape shape = CreateShape();
            shapes.Add(shape);

            // Gán tempBitmap vào một bitmap mới để tránh sự thay đổi tempBitmap khi tempBitmap được vẽ lên form
            Bitmap newBitmap = new Bitmap(tempBitmap);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                foreach (var s in shapes)
                {
                    s.Draw(g);
                }
            }

            tempBitmap = newBitmap;

            this.Invalidate();
        }

        private Shape CreateShape()
        {
            switch (currentTool)
            {
                case DrawingTool.Freehand:
                    return new FreehandShape(new Pen(currentColor, currentLineWidth), startPoint, endPoint);
                case DrawingTool.Rectangle:
                    return new RectangleShape(new Pen(currentColor, currentLineWidth), startPoint, endPoint);
                case DrawingTool.Ellipse:
                    return new EllipseShape(new Pen(currentColor, currentLineWidth), startPoint, endPoint);
                default:
                    return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
   
        }

        private void selectedShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTool = (DrawingTool)selectedShape.SelectedIndex;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = (float)numericUpDown1.Value;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.bmp|All files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDrawingToFile(saveFileDialog.FileName, Color.White);
            }
        }

        private void SaveDrawingToFile(string fileName, Color backgroundColor)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(backgroundColor);

                foreach (var shape in shapes)
                {
                    shape.Draw(g);
                }
            }

            bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }

    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public abstract void Draw(Graphics g);
    }

    public class FreehandShape : Shape
    {
        private Point startPoint;
        private Point endPoint;

        public FreehandShape(Pen pen, Point startPoint, Point endPoint)
        {
            this.Pen = pen;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, startPoint, endPoint);
        }
    }

    public class RectangleShape : Shape
    {
        private Rectangle rectangle;

        public RectangleShape(Pen pen, Point startPoint, Point endPoint)
        {
            this.Pen = pen;
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            this.rectangle = new Rectangle(x, y, width, height);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pen, rectangle);
        }
    }

    public class EllipseShape : Shape
    {
        private Rectangle rectangle;

        public EllipseShape(Pen pen, Point startPoint, Point endPoint)
        {
            this.Pen = pen;
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            this.rectangle = new Rectangle(x, y, width, height);
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pen, rectangle);
        }
    }
}
