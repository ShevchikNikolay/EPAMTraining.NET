using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry;
using PaintShop;


namespace Store
{
    public class Box
    {
        public const int MaxCount = 20;
        public List<Shape> Contents { get; set; }

        public Box()
        {
            Contents = new List<Shape>();
        }


        public void AddShape(Shape shape)
        {
            if (Contents.Count < 20)
            {
                if (!Contents.Contains(shape))
                {
                    Contents.Add(shape);
                }
                else
                {
                    throw new ArgumentException($"{shape} is already in the box.");
                }
            }
            throw new Exception("The box is full.");
        }

        public Shape GetShapeByNumber(int number)
        {
            if (Contents.Count > number)
            {
                return Contents[number];
            }
            else
            {
                throw new IndexOutOfRangeException($"Figure with number {number} isn't exist");
            }
        }

        public Shape ExtractShapeByNumber(int number)
        {
            Shape result;
            if (Contents.Count > number)
            {
                result = Contents[number];
                Contents.RemoveAt(number);
                return result;
            }
            else
            {
                throw new IndexOutOfRangeException($"Figure with number {number} isn't exist");
            }
        }
        public void ReplaceShapeByNumber(Shape shape, int number)
        {
            if (Contents.Count > number)
            {
                Contents[number] = shape;
            }
            else
            {
                throw new IndexOutOfRangeException($"Figure with number {number} isn't exist");
            }
        }
        public Shape GetEqualShape(Shape shape)
        {
            Shape result;
            result=Contents.Find(item => item.Equals(shape));
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception($"There are no figures equal to {shape}");
            }
        }

        public int GetCountOfShapes()
        {
            return Contents.Count;
        }
        public double GetTotalArea()
        {
            double result = 0;
            foreach (var item in Contents)
            {
                result += item.Area;
            }
            return result;
        }
        public double GetTotalPerimeter()
        {
            double result = 0;
            foreach (var item in Contents)
            {
                result += item.Perimeter;
            }
            return result;
        }

        public List<Shape> ExtractAllCircles()
        {
            var result = new List<Shape>();
            foreach (var item in Contents)
            {
                if(item is Circle)
                {
                    result.Add(item);
                    Contents.Remove(item);
                }
            }
            return result;
        }

        public List<Shape> ExtractAllFilmShapes()
        {
            var result = new List<Shape>();
            foreach (var item in Contents)
            {
                if (item.Color == Colores.Transparent)
                {
                    result.Add(item);
                    Contents.Remove(item);
                }
            }
            return result;
        }

        // ToDo xml
    }
}
