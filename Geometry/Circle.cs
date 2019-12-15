using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Circle : Shape
    {
        public double Radius { get; }
        public Circle(double radius, Material material) : base(material)
        {
            Radius = radius;
        }

        protected override double CalculateArea()
        {
            return (Math.PI * Radius * Radius);
        }

        protected override double CalculatePerimeter()
        {
            return (Math.PI * 2 * Radius);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            if(!(obj is Circle circle))
            {
                return false;
            }
            
            return (Radius == circle.Radius);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (Radius.GetHashCode()*31);
        }

        public override string ToString()
        {
            return ($"Shape:circle, Area:{Area}, Radius:{Radius}."); 
        }
    }
}
