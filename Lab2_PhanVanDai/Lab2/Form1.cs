namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.PaintEvent);
        }
        private void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string text = "Paint Event";

            Font paintFont = new Font("Arial", 16);
            Brush paintBrush = new SolidBrush(Color.Red);
            Random random = new Random();

            float x = random.Next(0, 400);
            float y = random.Next(0, 400);

            g.DrawString(text, paintFont, paintBrush, x, y);

            g.Dispose();

        }
    }
}