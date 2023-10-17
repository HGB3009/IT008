using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Circle : Shape
    {
        private double RADIUS;
        public double Radius {
            get {  return RADIUS; } 
            set {  RADIUS = value; }
        }

        public Circle(string name, string position, double radius)
            : base(name, position)
        {
            Radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine($"Ve hinh tron co ten {Name} tai vi tri {Position}");
            Console.WriteLine($"Ban kinh la: {Radius}");
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
