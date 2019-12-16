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
    /// Represents rectangle.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Initialize a new instance of the Rectangle class with given width, height and material.
        /// </summary>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <param name="material">Material of the rectangle.</param>
        public Rectangle(double width, double height, Material material): base(material)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Initialize a new instance of the Rectangle class with given width, height and parent shape.
        /// </summary>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <param name="shape">Material of the rectangle.</param>
        public Rectangle(double width, double height, ref Shape shape) : base(ref shape)
        {
            Width = width;
            Height = height;
            shape = null;
        }

        /// <summary>
        /// Calculate area of the rectangle.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return (Width * Height);
        }

        /// <summary>
        /// Calculate perimeter of the rectangle.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return ((Width + Height) * 2);
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

            if (!(obj is Rectangle rectangle))
            {
                return false;
            }

            return (GetArea() == rectangle.GetArea() && GetPerimeter() == rectangle.GetPerimeter());
        }

        /// <summary>
        /// Override Object.GetHashCode().
        /// </summary>
        /// <returns>HashCode of the object.</returns>
        public override int GetHashCode()
        {
            return (Width.GetHashCode() * 31 + Height.GetHashCode());
        }

        /// <summary>
        /// Override Object.ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"Shape:Rectangle, Area:{GetArea()}, Width:{Width}, Height:{Height}.");
        }

        /// <summary>
        /// Provide export information about the rectangle to the xml-file with XmlWriter.
        /// </summary>
        /// <param name="writer">The XmlWriter instance.</param>
        public override void ExportToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteElementString("Shape", "Rectangle");
            writer.WriteElementString("Color", $"{Color}");
            writer.WriteElementString("Width", $"{Width}");
            writer.WriteElementString("Height", $"{Height}");
            writer.WriteEndElement();
        }

        /// <summary>
        /// Provide export information about the rectangle to the xml-file with StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter instance.</param>
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
