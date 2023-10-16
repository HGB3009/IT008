using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public abstract class Shape
    {
        private string NAME;
        private string POSITION;
        public string Name
        { 
            get { return NAME; } 
            set { NAME = value; } 
        }
        public string Position
        {
            get { return POSITION; }
            set { POSITION = value; }
        }

        public Shape(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public abstract void Draw();
        public abstract double Area();
    }
}
