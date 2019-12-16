using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Geometry
{
    public class Circle : Shape
    {
        public double Radius { get; }
        public Circle(double radius, Material material) : base(material)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return (Math.PI * Radius * Radius);
        }

        public override double GetPerimeter()
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
            return (Radius.GetHashCode() * 31);
        }

        public override string ToString()
        {
            return ($"Shape:Circle, Area:{GetArea()}, Radius:{Radius}."); 
        }

        public override void ExportToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteElementString("Shape", "Circle");
            writer.WriteElementString("Color", $"{Color}");
            writer.WriteElementString("Radius", $"{Radius}");
            writer.WriteEndElement();
        }

        public override void ExportToXml(StreamWriter writer)
        {
            writer.WriteLine("<Figure>");
            writer.WriteLine("<Shape>Circle</Shape>");
            writer.WriteLine($"<Color>{Color}</Color>");
            writer.WriteLine($"<Radius>{Radius}</Radius>");
            writer.WriteLine("/Figuree");
        }
    }
}
