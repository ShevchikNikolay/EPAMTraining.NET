using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    public class Rectangle: Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }


        public Rectangle(double width, double height, Material material): base(material)
        {
            Width = width;
            Height = height;
            Area = CalculateArea();
            Perimeter = CalculatePerimeter();
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
