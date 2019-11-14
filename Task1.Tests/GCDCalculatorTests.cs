using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class GCDCalculatorTests
    {
        [TestMethod]
        public void EucldeanGCD_50and30_10returned()
        {
            #region arrange

            int a = 30;
            int b = 50;
            int expected = 10;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            int actual = calc.EuclideanGCD(a, b);

            #endregion



            #region assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]

        public void EuclideanGCD_OnInput0_0returned()
        {
            #region arrange

            int a = 0;
            int b = 50;
            int expected = 0;

            #endregion



            #region act

            GCDCalculator calc = new GCDCalculator();
            int actual = calc.EuclideanGCD(a, b);

            #endregion



            #region assert

            Assert.AreEqual(expected, actual);

            #endregion
        }
    }
}