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
    public enum Material
    {
        Film,
        Paper
    }
    public abstract class Shape : IPaintable
    {
        public Colores Color { get; private set; }

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

        public Shape(ref Shape shape)
        {
            Color = shape.Color;
        }


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

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public abstract void ExportToXml(XmlWriter writer);

        public abstract void ExportToXml(StreamWriter writer);

        // override object.Equals
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

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (GetArea().GetHashCode() * 31 + GetPerimeter().GetHashCode());
        }
    }
}
