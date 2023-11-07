namespace Lab2_ToVinhTien_22521474
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.PaintEvent);
        }
        private void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string text = "Paint Event";

            Font paintFont = new Font("Times New Roman", 13);
            Brush paintBrush = new SolidBrush(Color.Green);
            Random random = new Random();

            float x = random.Next(0, 400);
            float y = random.Next(0, 400);

            g.DrawString(text, paintFont, paintBrush, x, y);

            g.Dispose();
        }
    }
}