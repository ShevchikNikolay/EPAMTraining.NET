using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Представляет многочлен от одной переменной.
    /// </summary>
    public class Polynomial
    {
        
        public double[] Coefficients { get; private set; }  //массив коэффициентов. индекс массива = степени переменной

        /// <summary>
        /// Создает новый полином с переданными коэффициентами.
        /// </summary>
        /// <param name="coefficients">Массив коэффициентов.</param>
        public Polynomial(double[] coefficients)
        {
            Coefficients = coefficients;
        }

        /// <summary>
        /// Оператор сложения.
        /// </summary>
        /// <param name="left">Первое слогаемое(полином)</param>
        /// <param name="right">Второе слогаемое(полином)</param>
        /// <returns>Результат вычислений(полином)</returns>
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            int resultLength;
            if (left.Coefficients.Length > right.Coefficients.Length)
            {
                resultLength = left.Coefficients.Length;
            }
            else
            {
                resultLength = right.Coefficients.Length;
            }

            double[] resultCoefficients = new double[resultLength];

            for(var i = 0; i < left.Coefficients.Length; i++)
            {
                resultCoefficients[i] += left.Coefficients[i];
            }
            for(var i=0; i < right.Coefficients.Length; i++)
            {
                resultCoefficients[i] += right.Coefficients[i];
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Оператор вычетания.
        /// </summary>
        /// <param name="left">Полином - уменьшаемое</param>
        /// <param name="right">Полином - вычетаемое</param>
        /// <returns>Разность полиномов</returns>
        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            int resultLength;
            if (left.Coefficients.Length > right.Coefficients.Length)
            {
                resultLength = left.Coefficients.Length;
            }
            else
            {
                resultLength = right.Coefficients.Length;
            }

            double[] resultCoefficients = new double[resultLength];

            for (var i = 0; i < left.Coefficients.Length; i++)
            {
                resultCoefficients[i] += left.Coefficients[i];
            }
            for (var i = 0; i < right.Coefficients.Length; i++)
            {
                resultCoefficients[i] -= right.Coefficients[i];
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Оператор умножения.
        /// </summary>
        /// <param name="left">Первый множитель(полином).</param>
        /// <param name="right">Второй множитель(полином).</param>
        /// <returns>Произведение полиномов.</returns>
        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            /*Т.к. Старшая степень произведения полиномов равна сумме старших степеней
             множителей, а длина массива коэффициентов равна старшей степени + свободный член,
             то сумму длин исходных массивов уменьшим на 1*/
            double[] resultCoefficients = new double[left.Coefficients.Length + right.Coefficients.Length - 1];


            //Почленное перемножение с группировкой по степеням переменной.
            for(var i = 0; i < left.Coefficients.Length; i++)
            {
                for(var j = 0; j < right.Coefficients.Length; j++)
                {
                    resultCoefficients[i + j] += left.Coefficients[i] * right.Coefficients[j];
                }
            }

            return new Polynomial(resultCoefficients);
        }

    }
}
