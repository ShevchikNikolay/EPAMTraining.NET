using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Task1
{
    /// <summary>
    /// Представляет данные для гистограммы (Название метода вычисления и затраченное время.)
    /// </summary>
    public struct Gisto
    {
        public string methodName;
        public TimeSpan elapsedTime;

        public Gisto(string name, TimeSpan time)
        {
            methodName = name;
            elapsedTime = time;
        }
    }
    public class GCDCalculator
    {
        private Stopwatch sw;

        public GCDCalculator()
        {
            sw = new Stopwatch();
        }

        /// <summary>
        /// Вычисляет НОД двух целых чисел по Алгоритму Евклида.
        /// </summary>
        /// <param name="a">Целое число</param>
        /// <param name="b">Целое число</param>
        /// <param name="time">время затраченное на вычисление</param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, out TimeSpan time)
        {
            sw.Start();

            // Делителем 0 может быть любое число, поэтому поиск НОД бессмыслен.
            if (a == 0 && b == 0) 
            {
                sw.Stop();
                sw.Reset();
                throw new ArgumentException("Все числа не могут быть равны 0");
            }

            //избавляемся от минусов.
            a = Math.Abs(a);
            b = Math.Abs(b);

            //Заменяем большее число остатком от деления большего на меньшее до тех пор, пока остаток не будет равен 0.
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            sw.Stop();
            time += sw.Elapsed;
            sw.Reset();

            //Т.к. не известно в какой переменной окажется 0, возвращаем их сумму. (0+НОД = НОД)
            return (a + b);
        }

        /// <summary>
        ///Вычисляет НОД трех целых чисел по Алгоритму Евклида.
        /// </summary>
        /// <param name="a">Целое число</param>
        /// <param name="b">Целое число</param>
        /// <param name="c">Целое число</param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, int c)
        {
            int nod = 0;
            TimeSpan time;

            if (a != 0 || b != 0)
            {
                nod = EuclideanGCD(a, b, out time);
            }
            if (c != 0 || nod != 0)
            {
                nod = EuclideanGCD(c, nod, out time);
            }
            else
            {
                throw new ArgumentException("Все числа не могут быть равны 0");
            }
            return nod;
        }

        /// <summary>
        /// Вычисляет НОД четырех целых чисел по Алгоритму Евклида.
        /// </summary>
        /// <param name="a">Целое число</param>
        /// <param name="b">Целое число</param>
        /// <param name="c">Целое число</param>
        /// <param name="d">Целое число</param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, int c, int d)
        {

            int nod = 0;
            TimeSpan time;

            if (a != 0 || b != 0) 
            {
                nod = EuclideanGCD(a, b, out time);
            }
            if (c != 0 || nod != 0)
            {
                nod = EuclideanGCD(c, nod, out time);
            }
            if (d != 0 || nod != 0)
            {
                nod = EuclideanGCD(d, nod, out time);
            }
            else
            {
                throw new ArgumentException("Все числа не могут быть равны 0");
            }
            return nod;
        }

        /// <summary>
        /// Вычисляет НОД пяти целых чисел по Алгоритму Евклида.
        /// </summary>
        /// <param name="a">Целое число</param>
        /// <param name="b">Целое число</param>
        /// <param name="c">Целое число</param>
        /// <param name="d">Целое число</param>
        /// <param name="e">Целое число</param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, int c, int d, int e)
        {
            int nod = 0;
            TimeSpan time;

            if (a != 0 || b != 0)
            {
                nod = EuclideanGCD(a, b, out time);
            }
            if (c != 0 || nod != 0)
            {
                nod = EuclideanGCD(c, nod, out time);
            }
            if (d != 0 || nod != 0)
            {
                nod = EuclideanGCD(d, nod, out time);
            }
            if (e != 0 || nod != 0)
            {
                nod = EuclideanGCD(e, nod, out time);
            }
            else
            {
                throw new ArgumentException("Все числа не могут быть равны 0");
            }
            return nod;
        }
        /// <summary>
        /// Вычисляет НОД двух целых чисел по бинарному алгоритму.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="time">время затраченное на вычисление</param>
        /// <returns></returns>
        public int BinaryGCD(int a, int b, out TimeSpan time)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Все числа не могут быть равны 0");
            }
            a = Math.Abs(a);
            b = Math.Abs(b);
            sw.Start();

            if (a == 0 || b == 0)
            {
                sw.Stop();
                time += sw.Elapsed;
                sw.Reset();
                return (a+b);
            }
            if (a == b)
            {
                sw.Stop();
                time += sw.Elapsed;
                sw.Reset();
                return a;
            }

            bool aIsEven = a % 2 == 0;
            bool bIsEven = b % 2 == 0;

            //Оба числа четные - ищем НОД их половин и умножаем на 2.
            if (aIsEven && bIsEven)
            {
                sw.Stop();
                return (BinaryGCD(a >> 1, b >> 1, out time) << 1);
            }
            //если одно из чисел четное - делим его на 2 и ищем НОД получившейся пары
            else if (aIsEven && !bIsEven)
            {
                sw.Stop();
                return BinaryGCD(a >> 1, b, out time);
            }
            else if (bIsEven)
            {
                sw.Stop();
                return BinaryGCD(a, b >> 1, out time);
            }
            //если оба числа не четные, то заменяем большее половиной разности двух чисел и ищем НОД получившейся пары.
            else if (a > b)
            {
                sw.Stop();
                return BinaryGCD((a - b) >> 1, b, out time);
            }
            else
            {
                sw.Stop();
                return BinaryGCD(a, (b - a) >> 1, out time);
            }


        }

        /// <summary>
        /// Подготавливает данные о времени, затрачиваемом на вычисление НОД различными методами, для построения гистограммы.
        /// </summary>
        /// <param name="a">Целое число</param>
        /// <param name="b">Целое число</param>
        /// <returns></returns>
        public List<Gisto> PrepareDataToCompare(int a, int b)
        {
            List<Gisto> result = new List<Gisto>();
            EuclideanGCD(a, b, out TimeSpan time1);
            BinaryGCD(a, b, out TimeSpan time2);
            result.Add(new Gisto("Euclidean", time1));
            result.Add(new Gisto("Binary", time2));
            return result;
        }
    }
}
