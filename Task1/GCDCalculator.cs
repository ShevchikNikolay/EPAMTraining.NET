using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class GCDCalculator
    {
        /// <summary>
        /// Вычисляет НОД двух целых чисел по Алгоритму Евклида. Если одно из чисел 0 - возвращает 0.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int EuclideanGCD(int a, int b)
        {
            if (a == 0 || b == 0)
            {
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
            int nod = EuclideanGCD(a, b);
            nod = EuclideanGCD(c, nod);
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
            int nod = EuclideanGCD(a, b);
            nod = EuclideanGCD(c, nod);
            nod = EuclideanGCD(d, nod);
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
            int nod = EuclideanGCD(a, b);
            nod = EuclideanGCD(c, nod);
            nod = EuclideanGCD(d, nod);
            nod = EuclideanGCD(e, nod);
            return nod;
        }
    }
}
