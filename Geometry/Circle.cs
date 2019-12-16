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
    /// Represents Circle.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Radius of circle
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Initialize a new instance of the Circle class with given radius and material. 
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        /// <param name="material">Material of the circle.</param>
        public Circle(double radius, Material material) : base(material)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculate area of the circle.
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return (Math.PI * Radius * Radius);
        }

        /// <summary>
        /// Calculate perimeter of the circle.
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
        {
            return (Math.PI * 2 * Radius);
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

            if(!(obj is Circle circle))
            {
                return false;
            }
            
            return (Radius == circle.Radius);
        }

        /// <summary>
        /// Override Object.GetHashCode().
        /// </summary>
        /// <returns>HashCode of the object.</returns>
        public override int GetHashCode()
        {
            return (Radius.GetHashCode() * 31);
        }

        /// <summary>
        /// Override Object.ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"Shape:Circle, Area:{GetArea()}, Radius:{Radius}."); 
        }

        /// <summary>
        /// Provide export information about the circle to the xml-file with XmlWriter.
        /// </summary>
        /// <param name="writer">The XmlWriter instance.</param>
        public override void ExportToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteElementString("Shape", "Circle");
            writer.WriteElementString("Color", $"{Color}");
            writer.WriteElementString("Radius", $"{Radius}");
            writer.WriteEndElement();
        }

        /// <summary>
        /// Provide export information about the circle to the xml-file with StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter instance.</param>
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
