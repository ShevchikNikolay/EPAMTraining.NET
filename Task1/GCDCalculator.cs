using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class GCDCalculator
    {/// <summary>
    /// Вычисляет НОД двух целых чисел по Алгоритму Евклида. В случае ввода 0 возвращает 0.
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
    }
}
