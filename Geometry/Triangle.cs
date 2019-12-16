using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Geometry
{
    /// <summary>
    /// Represents triangle.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Length of the first side of the triangle.
        /// </summary>
        public double FirstSide { get; }

        /// <summary>
        /// Length of the second side of the triangle.
        /// </summary>
        public double SecondSide { get; }

        /// <summary>
        /// Length of the third side of the triangle.
        /// </summary>
        public double ThirdSide { get; }

        /// <summary>
        /// Initialize a new instance of the Rectangle class.
        /// </summary>
        /// <param name="firstSide">The first side of the triangle</param>
        /// <param name="secondSide">The second side of the triangle.</param>
        /// <param name="thirdSide">The third side of the triangle.</param>
        /// <param name="material">The material of the triangle.</param>
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

        /// <summary>
        /// Initialize a new instance of the Rectangle class.
        /// </summary>
        /// <param name="firstSide">The first side of the triangle</param>
        /// <param name="secondSide">The second side of the triangle.</param>
        /// <param name="thirdSide">The third side of the triangle.</param>
        /// <param name="shape">Parent figure</param>
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

        /// <summary>
        /// Calculate the height of the triangle.
        /// </summary>
        /// <returns></returns>
        public double GetHeight()
        {
            return (GetArea() / (FirstSide / 2));
        }

        /// <summary>
        /// Calculate the area of the triangle.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            var p = GetPerimeter() / 2;

            return (Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide)));
        }

        /// <summary>
        /// Calculate the perimeter of the triangle.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return (FirstSide + SecondSide + ThirdSide);
        }

        /// <summary>
        /// Override Object.Equals().
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if objects are identical.</returns>
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

        /// <summary>
        /// Override Object.GetHashCode().
        /// </summary>
        /// <returns>HashCode of the object.</returns>
        public override int GetHashCode()
        {
            var hash = FirstSide.GetHashCode();
            hash = hash * 31 + SecondSide.GetHashCode();
            hash = hash * 31 + ThirdSide.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Override Object.ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"Shape:Triangle, Area:{GetArea()}, FirstSide:{FirstSide}, SecondSide:{SecondSide}, ThirdSide:{ThirdSide}.");
        }

        /// <summary>
        /// Provide export information about the triangle to the xml-file with XmlWriter.
        /// </summary>
        /// <param name="writer">The XmlWriter instance.</param>
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

        /// <summary>
        /// Provide export information about the triangle to the xml-file with StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter instance.</param>
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
