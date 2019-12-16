using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public Rectangle(double width, double height, ref Shape shape) : base(ref shape)
        {
            Width = width;
            Height = height;
            shape = null;
        }

        public override double GetArea()
        {
            return (Width * Height);
        }

        public override double GetPerimeter()
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

            return (GetArea() == rectangle.GetArea() && GetPerimeter() == rectangle.GetPerimeter());
        }
        public override int GetHashCode()
        {
            return (Width.GetHashCode() * 31 + Height.GetHashCode());
        }
        public override string ToString()
        {
            return ($"Shape:Rectangle, Area:{GetArea()}, Width:{Width}, Height:{Height}.");
        }

        public override void ExportToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteElementString("Shape", "Rectangle");
            writer.WriteElementString("Color", $"{Color}");
            writer.WriteElementString("Width", $"{Width}");
            writer.WriteElementString("Height", $"{Height}");
            writer.WriteEndElement();
        }

        public override void ExportToXml(StreamWriter writer)
        {
            writer.WriteLine("<Figure>");
            writer.WriteLine("<Shape>Rectangle</Shape>");
            writer.WriteLine($"<Color>{Color}</Color>");
            writer.WriteLine($"<Width>{Width}</Width>");
            writer.WriteLine($"<Height>{Height}</Height>");
            writer.WriteLine("/Figure");
        }
    }
}
