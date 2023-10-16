using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Square : Rectangle
    {
        private double SIDE;
        public double Side 
        {
            get {  return SIDE; }
            set { SIDE = value; }
        }

        public Square(string name, string position, double side)
            : base(name, position, side, side)
        {
            Side = side;
        }
        public override void Draw()
        {
            Console.WriteLine($"Ve hinh vuong co ten {Name} tai vi tri {Position}");
            Console.WriteLine($"Chieu dai canh la: {Side}");
        }

        public override double Area()
        {
            return Side * Side;
        }
    }
}
