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
        private bool isFirstIteration;


        public GCDCalculator()
        {
            sw = new Stopwatch();
            isFirstIteration = true;
        }

        /// <summary>
        /// Вычисляет НОД двух целых чисел по Алгоритму Евклида. Если одно из чисел 0 - возвращает 0.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, out TimeSpan time)
        {
            sw.Start();
            if (a == 0 || b == 0)
            {
                sw.Stop();
                time += sw.Elapsed;
                sw.Reset();
                return 0;
            }

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
            return (a + b);
        }

        /// <summary>
        ///Вычисляет НОД трех целых чисел по Алгоритму Евклида. Если одно из чисел 0 - возвращает 0.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, int c)
        {
            int nod = EuclideanGCD(a, b, out TimeSpan time);
            nod = EuclideanGCD(c, nod,  out time);
            return nod;
        }

        /// <summary>
        /// Вычисляет НОД четырех целых чисел по Алгоритму Евклида. Если одно из чисел 0 - возвращает 0.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, int c, int d)
        {
            int nod = EuclideanGCD(a, b, out TimeSpan time);
            nod = EuclideanGCD(c, nod, out time);
            nod = EuclideanGCD(d, nod, out time);
            return nod;
        }

        /// <summary>
        /// Вычисляет НОД пяти целых чисел по Алгоритму Евклида. Если одно из чисел 0 - возвращает 0.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b, int c, int d, int e)
        {
            int nod = EuclideanGCD(a, b, out TimeSpan time);
            nod = EuclideanGCD(c, nod, out time);
            nod = EuclideanGCD(d, nod, out time);
            nod = EuclideanGCD(e, nod, out time);
            return nod;
        }
        /// <summary>
        /// Вычисляет НОД двух целых чисел по бинарному алгоритму. Если одно из чисел 0 - возвращает 0.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="time">время затраченное на вычисление</param>
        /// <returns></returns>
        public int BinaryGCD(int a, int b, out TimeSpan time)
        {
            if (isFirstIteration == true)
            {
                isFirstIteration = false;
                sw.Start();
                if (a == 0 || b == 0)
                {
                    sw.Stop();
                    time += sw.Elapsed;
                    sw.Reset();
                    isFirstIteration = true;
                    return 0;
                }
            }
            if (a == 0)
            {
                sw.Stop();
                time += sw.Elapsed;
                sw.Reset();
                isFirstIteration = true;
                return b;
            }
            if (b == 0)
            {
                sw.Stop();
                time += sw.Elapsed;
                sw.Reset();
                isFirstIteration = true;
                return a;
            }
            if (a == b)
            {
                sw.Stop();
                time += sw.Elapsed;
                sw.Reset();
                isFirstIteration = true;
                return a;
            }

            bool aIsEven = a % 2 == 0;
            bool bIsEven = b % 2 == 0;

            if (aIsEven && bIsEven)
            {
                return (BinaryGCD(a >> 1, b >> 1, out time) << 1);
            }
            else if (aIsEven && !bIsEven)
            {
                return BinaryGCD(a >> 1, b, out time);
            }
            else if (bIsEven)
            {
                return BinaryGCD(a, b >> 1, out time);
            }
            else if (a > b)
            {
                return BinaryGCD((a - b) >> 1, b, out time);
            }
            else
            {
                return BinaryGCD(a, (b - a) >> 1, out time);
            }


        }

        /// <summary>
        /// Подготавливает данные о времени, затрачиваемом на вычисление НОД различными методами, для построения гистограммы.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
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
