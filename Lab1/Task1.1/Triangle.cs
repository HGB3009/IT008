using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Triangle : Shape

    { 
        private double BaseS;
        public double Base 
        { 
            get { return BaseS; }
            set { BaseS = value; }
        }
        public double Height { get; set; }

        public Triangle(string name, string position, double BaSe, double height)
            : base(name, position)
        {
            Base = BaSe;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Ve hinh tam giac co ten {Name} tai vi tri {Position}"); 
            Console.WriteLine($"Chieu dai canh co so la: {Base}");
            Console.WriteLine($"Chieu cao la: {Height}");
        }

        public override double Area()
        {
            return 0.5 * Base * Height;
        }
    }

}
