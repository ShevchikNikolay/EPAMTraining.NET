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

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            if (!(obj is Rectangle rectangle))
            {
                return false;
            }

            return (Area == rectangle.Area && Perimeter == rectangle.Perimeter);
        }
        public override int GetHashCode()
        {
            return (Width.GetHashCode() * 31 + Height.GetHashCode());
        }
        public override string ToString()
        {
            return ($"Shape:rectangle, Area:{Area}, Width:{Width}, Height:{Height}.");
        }
    }
}
