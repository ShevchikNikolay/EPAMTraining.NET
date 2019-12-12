using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }


        public Rectangle(double width, double height, Material material): base(material)
        {
            Width = width;
            Height = height;
        }

        protected override double CalculateArea()
        {
            return (Width * Height);
        }

        protected override double CalculatePerimeter()
        {
            return ((Width + Height) * 2);
        }
    }
}
