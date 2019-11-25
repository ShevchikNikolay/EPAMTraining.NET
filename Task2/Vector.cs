using System;

namespace Task2
{
    /// <summary>
    /// Экземпляры класса представляют собой вектор, заданный в координатной форме.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Координата x.
        /// </summary>
        public double X { get;  private set; }
        /// <summary>
        /// Координата y.
        /// </summary>
        public double Y { get; private set; }
        /// <summary>
        /// Координата z.
        /// </summary>
        public double Z { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="x">координата x.</param>
        /// <param name="y">координата y.</param>
        /// <param name="z">координата z.</param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Возвращает длину вектора.
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Оператор сложения.
        /// </summary>
        /// <param name="v1">Первый слогаемый вектор.</param>
        /// <param name="v2">Второй слогаемый вектор.</param>
        /// <returns>Суммарный вектор.</returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Оператор вычитания.
        /// </summary>
        /// <param name="v1">Уменьшаемый вектор.</param>
        /// <param name="v2">Вычитаемый вектор.</param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Оператор умножения.
        /// </summary>
        /// <param name="v">Умножаемый вектор.</param>
        /// <param name="n">число - множитель.</param>
        /// <returns>Произведение вектора на число (Вектор).</returns>
        public static Vector operator *(Vector v, double n)
        {
            return new Vector(v.X * n, v.Y * n, v.Z * n);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v2 is null)
            {
                return false;
            }
            return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            if(v2 is null)
            {
                return true;
            }
            return (v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z);
        }

        public static bool operator < (Vector v1, Vector v2)
        {
            return (v1.GetLength() < v2.GetLength());
        }
        public static bool operator > (Vector v1, Vector v2)
        {
            return (v1.GetLength() > v2.GetLength());
        }
        public override bool Equals(object obj)
        {
            var item = obj as Vector;
            if (item == null)
            {
                return false;
            }

            return (X.Equals(item.X) && Y.Equals(item.Y) && Z.Equals(item.Z));
        }
        public override int GetHashCode()
        {
            int hash;
            hash = X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            hash = hash * 31 + Z.GetHashCode();
            return hash;

            
        }
    }
}
