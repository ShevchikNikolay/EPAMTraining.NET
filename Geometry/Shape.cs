using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PaintShop;


namespace Geometry
{
    /// <summary>
    /// Materials for figures.
    /// </summary>
    public enum Material
    {
        /// <summary>
        /// Film material.
        /// </summary>
        Film,

        /// <summary>
        /// Paper material.
        /// </summary>
        Paper
    }

    /// <summary>
    /// An abstract class describes the shape of figures.
    /// </summary>
    public abstract class Shape : IPaintable
    {
        /// <summary>
        /// Colore of the figure.
        /// </summary>
        public Colores Color { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        public Shape(Material material)
        {
            if (material == Material.Film)
            {
                Color = Colores.Transparent;
            }
            else
            {
                Color = Colores.Colorless;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        public Shape(ref Shape shape)
        {
            Color = shape.Color;
        }

        /// <summary>
        /// Paint figure with given color.
        /// </summary>
        /// <param name="color"> Color to paint.</param>
        public void Paint(Colores color)
        {
            if (color == Colores.Transparent || color == Colores.Colorless)
            {
                throw new PaintingException("Wrong color.");
            }
            if (Color == Colores.Transparent)
            {
                throw new PaintingException("Wrong material.");
            }
            if (Color != Colores.Colorless)
            {
                throw new PaintingException("It can't be painting twice...");
            }
            else
            {
                Color = color;
            }
        }

        /// <summary>
        /// Abstract method for calculating area.
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();

        /// <summary>
        /// Abstract method for calculating perimeter.
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Abstract method for export figure to xml-file with XmlWriter.
        /// </summary>
        /// <param name="writer">The XmlWriter instance</param>
        public abstract void ExportToXml(XmlWriter writer);

        /// <summary>
        /// Abstract method for export figure to xml-file with StreamWriter.
        /// </summary>
        /// <param name="writer">The StreamWriter instance</param>
        public abstract void ExportToXml(StreamWriter writer);

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

            if (!(obj is Shape shape))
            {
                return false;
            }

            return (GetArea() == shape.GetArea() && GetPerimeter() == shape.GetPerimeter());
        }

        /// <summary>
        /// Override Object.GetHashCode().
        /// </summary>
        /// <returns>HashCode of the object.</returns>
        public override int GetHashCode()
        {
            return (GetArea().GetHashCode() * 31 + GetPerimeter().GetHashCode());
        }
    }
}
