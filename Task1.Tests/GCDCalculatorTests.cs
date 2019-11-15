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
        public void EuclideanGCD_Input0_0returned()
        {
            #region arrange

            int a = 0;
            int b = 50;
            int expected = 0;

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
        public void EuclideanGCD_Input0ForMultipleNumbers_0returned()
        {
            #region arrange

            int a = 500;
            int b = 34;
            int c = 0;
            int expected = 0;

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
        public void BinaryGCD_Input0_0returned()
        {
            #region arrange

            int a = 116150;
            int b = 0;
            int expected = 0;

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
    }
}