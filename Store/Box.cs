using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Geometry;
using PaintShop;


namespace Store
{
    /// <summary>
    /// Represents the box for figures.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Box capacity.
        /// </summary>
        public const int MaxCount = 20;

        /// <summary>
        /// Path to xml-file.
        /// </summary>
        public const string Path = @"..\..\Box.xml";

        /// <summary>
        /// Contents of the box.
        /// </summary>
        public List<Shape> Contents { get; set; }

        /// <summary>
        /// Initialize a new instance of the Box class.
        /// </summary>
        public Box()
        {
            Contents = new List<Shape>();
        }

        /// <summary>
        /// Add figure to the box.
        /// </summary>
        /// <param name="shape">Figure to adding.</param>
        public void AddShape(Shape shape)
        {
            if (Contents.Count < MaxCount)
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

        /// <summary>
        /// Show figure by it's index in the collection.
        /// </summary>
        /// <param name="number">Index.</param>
        /// <returns></returns>
        public Shape GetShapeByNumber(int number)
        {
            if (Contents.Count > number)
            {
                return Contents[number];
            }
            else
            {
                throw new IndexOutOfRangeException($"Figure with number {number} isn't exist.");
            }
        }

        /// <summary>
        /// Extract figures by it's index in the collection.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
                throw new IndexOutOfRangeException($"Figure with number {number} isn't exist.");
            }
        }

        /// <summary>
        /// Replace the figure in the collection by it's index with given figure.
        /// </summary>
        /// <param name="shape">Figure to replace</param>
        /// <param name="number">Index</param>
        public void ReplaceShapeByNumber(Shape shape, int number)
        {
            if (Contents.Count > number)
            {
                Contents[number] = shape;
            }
            else
            {
                throw new IndexOutOfRangeException($"Figure with number {number} isn't exist.");
            }
        }

        /// <summary>
        /// Find the figure in the collection by the given example.
        /// </summary>
        /// <param name="shape">Exemple to find.</param>
        /// <returns></returns>
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
                throw new Exception($"There are no figures equal to {shape}.");
            }
        }

        /// <summary>
        /// Shows how many figures are present in the box.
        /// </summary>
        /// <returns></returns>
        public int GetCountOfShapes()
        {
            return Contents.Count;
        }

        /// <summary>
        /// Calculate total area of figures in the box.
        /// </summary>
        /// <returns></returns>
        public double GetTotalArea()
        {
            double result = 0;
            foreach (var item in Contents)
            {
                result += item.GetArea();
            }
            return result;
        }

        /// <summary>
        /// Calculate total perimeter of figures in the box.
        /// </summary>
        /// <returns></returns>
        public double GetTotalPerimeter()
        {
            double result = 0;
            foreach (var item in Contents)
            {
                result += item.GetPerimeter();
            }
            return result;
        }

        /// <summary>
        /// Extract all cicles from the box.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Extract all figures, which material is film.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Provide export information about the box contents to the xml-file with XmlWriter.
        /// </summary>
        /// <param name="path">Path to the xml-file.</param>
        public void ExportToXmlWithXmlWriter(string path = Path)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };
            XmlWriter writer = XmlWriter.Create(path, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Box");

            foreach(var item in Contents)
            {
                item.ExportToXml(writer);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        /// <summary>
        /// Provide export information about the box contents to the xml-file with StreamWriter.
        /// </summary>
        /// <param name="path">Path to the xml-file.</param>
        public void ExportToXmlWithStreamWriter(string path = Path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf - 8""?>");
            writer.WriteLine("<Box>");

            foreach (var item in Contents)
            {
                item.ExportToXml(writer);
            }

            writer.WriteLine("</Box>");
            writer.Close();
        }

        /// <summary>
        /// Provide import information about the box contents from the xml-file with XmlReader.
        /// </summary>
        /// <param name="path">Path to the xml-file.</param>
        public void ImportFromXmlWithXmlReader(string path = Path)
        {
            Contents = new List<Shape>();
            using (XmlReader reader = XmlReader.Create(path))
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Parse
                };

                try
                {
                    reader.MoveToContent();
                }
                catch
                {
                    throw new Exception("Xml file does not contain figures.");
                }



                while (reader.Read())

                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Figure"))

                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(reader.ReadOuterXml());
                        XmlNode node = xmlDocument.SelectSingleNode("Figure");

                        Colores color = (Colores)Enum.Parse(typeof(Colores), Convert.ToString(node.SelectSingleNode("Color").InnerText));

                        string shape = node.SelectSingleNode("Shape").InnerText;

                        switch (shape)

                        {

                            case "Circle":

                                double radius = Convert.ToDouble(node.SelectSingleNode("Radius").InnerText);
                                if (color == Colores.Transparent)
                                {
                                    Circle circle = new Circle(radius, Material.Film);
                                    AddShape(circle);
                                }
                                else
                                {
                                    Circle circle = new Circle(radius, Material.Paper);
                                    if (color != Colores.Colorless)
                                    {
                                        circle.Paint(color);
                                        AddShape(circle);
                                    }
                                }
                                break;

                            case "Rectangle":

                                double width = Convert.ToDouble(node.SelectSingleNode("Width").InnerText);

                                double height = Convert.ToDouble(node.SelectSingleNode("Height").InnerText);

                                if (color == Colores.Transparent)
                                {
                                    Rectangle rectangle = new Rectangle(width, height, Material.Film);
                                    AddShape(rectangle);
                                }
                                else
                                {
                                    Rectangle rectangle = new Rectangle(width, height, Material.Paper);
                                    if (color != Colores.Colorless)
                                    {
                                        rectangle.Paint(color);
                                        AddShape(rectangle);
                                    }
                                }
                                break;


                            case "Triangle":

                                double firstSide = Convert.ToDouble(node.SelectSingleNode("FirstSide").InnerText);

                                double secondSide = Convert.ToDouble(node.SelectSingleNode("SecondSide").InnerText);

                                double thirdSide = Convert.ToDouble(node.SelectSingleNode("ThirdSide").InnerText);
                                if (color == Colores.Transparent)
                                {
                                    Triangle triangle = new Triangle(firstSide, secondSide, thirdSide, Material.Film);
                                    AddShape(triangle);
                                }
                                else
                                {
                                    Triangle triangle = new Triangle(firstSide, secondSide, thirdSide, Material.Paper);
                                    if (color != Colores.Colorless)
                                    {
                                        triangle.Paint(color);
                                        AddShape(triangle);
                                    }
                                }

                                break;

                        }

                    }

                }

            }
        }
    }
}
