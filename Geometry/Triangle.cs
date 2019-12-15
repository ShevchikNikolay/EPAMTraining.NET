using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Triangle : Shape
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        public Triangle(Material material, double firstSide, double secondSide, double thirdSide) : base(material)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public Triangle(Shape shape, double firstSide, double secondSide, double thirdSide) : base(shape)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        protected override double CalculateArea()
        {
            var p = Perimeter / 2;

            return (Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide)));
        }

        protected override double CalculatePerimeter()
        {
            return (FirstSide + SecondSide + ThirdSide);
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            if (!(obj is Triangle triangle))
            {
                return false;
            }

            return (Area == triangle.Area && Perimeter == triangle.Perimeter);
        }

        public override int GetHashCode()
        {
            var hash = FirstSide.GetHashCode();
            hash = hash * 31 + SecondSide.GetHashCode();
            hash = hash * 31 + ThirdSide.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return ($"Shape:triangle, Area:{Area}, Perimeter:{Perimeter}, FirstSide:{FirstSide}, SecondSide:{SecondSide}, ThirdSide:{ThirdSide}.");
        }

    }
}
