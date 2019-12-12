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

        protected override double CalculateArea()
        {
            var p = Perimeter / 2;

            return (Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide)));
        }

        protected override double CalculatePerimeter()
        {
            return (FirstSide + SecondSide + ThirdSide);
        }
    }
}
