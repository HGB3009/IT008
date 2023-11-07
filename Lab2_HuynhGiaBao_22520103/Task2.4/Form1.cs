using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task2._4
{
    public partial class Form1 : Form
    {
        private Random random = new Random(); // Khai báo đối tượng Random

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Lấy kích thước của Form
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Tạo vị trí ngẫu nhiên
            int x = random.Next(formWidth);
            int y = random.Next(formHeight);

            // Vẽ chuỗi "Paint Event" tại vị trí ngẫu nhiên trên Form
            g.DrawString("Paint Event", new Font("Arial", 12), Brushes.Black, new PointF(x, y));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện Paint của Form
            this.Paint += new PaintEventHandler(Form1_Paint); // Sửa tên sự kiện thành Form1_Paint

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
