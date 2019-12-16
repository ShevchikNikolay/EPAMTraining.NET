using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Geometry
{
    public class Triangle : Shape
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        public Triangle(double firstSide, double secondSide, double thirdSide, Material material) : base(material)
        {
            if (firstSide == 0 || secondSide == 0 || thirdSide == 0)
            {
                throw new ArgumentException("Side of triangle can't be 0.");
            }
            FirstSide = firstSide;
            if (FirstSide > secondSide)
            {
                SecondSide = secondSide;
            }
            else
            {
                SecondSide = firstSide;
                FirstSide = secondSide;
            }
            if (FirstSide > thirdSide)
            {
                ThirdSide = thirdSide;
            }
            else
            {
                ThirdSide = FirstSide;
                FirstSide = thirdSide;
            }

            if (FirstSide >= SecondSide + ThirdSide)
            {
                throw new Exception("Imposible to create the triangle with such sides.");
            }
        }

        public Triangle(double firstSide, double secondSide, double thirdSide, ref Shape shape) : base(ref shape)
        {
            if (firstSide == 0 || secondSide == 0 || thirdSide == 0)
            {
                throw new ArgumentException("Side of triangle can't be 0.");
            }
            FirstSide = firstSide;
            if (FirstSide > secondSide)
            {
                SecondSide = secondSide;
            }
            else
            {
                SecondSide = firstSide;
                FirstSide = secondSide;
            }
            if (FirstSide > thirdSide)
            {
                ThirdSide = thirdSide;
            }
            else
            {
                ThirdSide = FirstSide;
                FirstSide = thirdSide;
            }

            switch (shape)
            {
                case Circle circle:
                    double circleRadius = (FirstSide * SecondSide * ThirdSide / (4 * GetArea()));
                    if (circle.Radius < circleRadius)
                    {
                        throw new Exception($"You can't cut such big triangle.");
                    }
                    break;
                case Rectangle rectangle:
                    if (FirstSide > rectangle.Width || GetHeight() > rectangle.Height)
                    {
                        throw new Exception($"You can't cut such big triangle.");
                    }
                    break;

                case Triangle triangle:
                    if (FirstSide > triangle.FirstSide || GetArea() >= triangle.GetArea())
                    {
                        throw new Exception($"You can't cut such big triangle.");
                    }
                    break;
            }
            shape = null;
        }

        public double GetHeight()
        {
            return (GetArea() / (FirstSide / 2));
        }

        public override double GetArea()
        {
            var p = GetPerimeter() / 2;

            return (Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide)));
        }

        public override double GetPerimeter()
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

            return (GetArea() == triangle.GetArea() && GetPerimeter() == triangle.GetPerimeter());
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
            return ($"Shape:Triangle, Area:{GetArea()}, FirstSide:{FirstSide}, SecondSide:{SecondSide}, ThirdSide:{ThirdSide}.");
        }

        public override void ExportToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteElementString("Shape", "Triangle");
            writer.WriteElementString("Color", $"{Color}");
            writer.WriteElementString("FirstSide", $"{FirstSide}");
            writer.WriteElementString("SecondSide", $"{SecondSide}");
            writer.WriteElementString("ThirdSide", $"{ThirdSide}");
            writer.WriteEndElement();
        }

        public override void ExportToXml(StreamWriter writer)
        {
            writer.WriteLine("<Figure>");
            writer.WriteLine("<Shape>Rectangle</Shape>");
            writer.WriteLine($"<Color>{Color}</Color>");
            writer.WriteLine($"<FirstSide>{FirstSide}</FirstSide>");
            writer.WriteLine($"<SecondSide>{SecondSide}</SecondSide>");
            writer.WriteLine($"<ThirdSide>{ThirdSide}</ThirdSide>");
            writer.WriteLine("/Figure");
        }
    }
}
