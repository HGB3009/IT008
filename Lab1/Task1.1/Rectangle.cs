using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Rectangle : Shape
    {
        private double WIDTH;
        private double HEIGHT;
        public double Width 
        {
            get {  return WIDTH; } 
            set {  WIDTH = value; }
        }
        public double Height 
        { 
            get { return HEIGHT; } 
            set {  HEIGHT = value; }
        }

        public Rectangle(string name, string position, double width, double height)
            : base(name, position)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Ve hinh chu nhat co ten {Name} tai vi tri {Position}");
            Console.WriteLine($"Co chieu dai la: {Height}");
            Console.WriteLine($"Co chieu rong la: {Width}");
        }

        public override double Area()
        {
            return Width * Height;
        }
    }
}
