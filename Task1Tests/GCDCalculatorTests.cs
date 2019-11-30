using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Task1.Tests
{
    [TestClass]
    public class GCDCalculatorTests
    {
        [TestMethod]
        public void EucldeanGCD_CorrectInput_202returned()
        {
            #region arrange

            int a = 116150;
            int b = 232704;
            int expected = 202;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            int actual = calc.EuclideanGCD(a, b, out TimeSpan time);
            Debug.WriteLine(time.TotalMilliseconds);

            #endregion



            #region assert

            Assert.AreEqual(expected, actual);

            #endregion
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanGCD_BothInputs0_ArgumentException()
        {
            #region arrange

            int a = 0;
            int b = 0;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            calc.EuclideanGCD(a, b, out TimeSpan time);
            Debug.WriteLine(time.TotalMilliseconds);

            #endregion
        }

        [TestMethod]
        public void EuclideanGCD_CorrectInputForMultipleNumbers_2returned()
        {
            #region arrange

            int a = 500;
            int b = 34;
            int c = 156;
            int expected = 2;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            int actual = calc.EuclideanGCD(a, b, c);

            #endregion



            #region assert

            Assert.AreEqual(expected, actual);

            #endregion
        }
        [TestMethod]
        public void EuclideanGCD_LastNumberNotZero_156returned()
        {
            #region arrange

            int a = 0;
            int b = 0;
            int c = 156;
            int expected = 156;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            int actual = calc.EuclideanGCD(a, b, c);

            #endregion



            #region assert

            Assert.AreEqual(expected, actual);

            #endregion
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanGCD_AllOfInputsAre0_ArgumentException()
        {
            #region arrange

            int a = 0;
            int b = 0;
            int c = 0;

            #endregion
            #region act

            GCDCalculator calc = new GCDCalculator();
            calc.EuclideanGCD(a, b, c);

            #endregion
        }

        [TestMethod]
        public void BinaryGCD_CorrectInput_202returned()
        {
            #region arrange

            int a = 116150;
            int b = 232704;
            int expected = 202;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            int actual = calc.BinaryGCD(a, b, out TimeSpan time);
            Debug.WriteLine(time.TotalMilliseconds);

            #endregion



            #region assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinaryGCD_Input0_ArgumentException()
        {
            #region arrange

            int a = 0;
            int b = 0;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            calc.BinaryGCD(a, b, out TimeSpan time);
            Debug.WriteLine(time.TotalMilliseconds);

            #endregion
        }
    }
}