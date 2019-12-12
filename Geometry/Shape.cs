using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public double Area { get; set; }
        public double Perimeter { get; set; }
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
            Perimeter = CalculatePerimeter();
            Area = CalculateArea();
        }

        public Shape(Shape shape)
        {
            Color = shape.Color;
            Perimeter = CalculatePerimeter();
            Area = CalculateArea();
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

        protected abstract double CalculateArea();
        protected abstract double CalculatePerimeter();

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


            return (Area == shape.Area && Perimeter == shape.Perimeter);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {

            return (Area.GetHashCode()*31+Perimeter.GetHashCode());
        }
    }
}
