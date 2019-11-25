using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Task2.Tests
{
    [TestClass]
    public class PolynomialTests
    {

        [TestMethod]
        public void OperationAdd()
        {
            //arrange

            Polynomial left = new Polynomial(new double[] { 3, -8, 4 });    // 4x^2 - 8x + 3
            Polynomial right = new Polynomial(new double[] { -1, 0, 2 });   // 2x^2 - 1
            Polynomial expected = new Polynomial(new double[] { 2, -8, 6 });// 6x^2 - 8x + 2

            //action
            Polynomial actual = left + right;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperationSubtraction()
        {
            //arrange
            Polynomial left = new Polynomial(new double[] { 3, -8, 4 });    // 4x^2 - 8x + 3
            Polynomial right = new Polynomial(new double[] { -1, 0, 2 });   // 2x^2 - 1
            Polynomial expected = new Polynomial(new double[] { 4, -8, 2 });// 2x^2 - 8x + 4

            //action
            Polynomial actual = left - right;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperationMultiplication()
        {
            //arrange
            Polynomial left = new Polynomial(new double[] { 3, -8, 4 });    // 4x^2 - 8x + 3
            Polynomial right = new Polynomial(new double[] { -1, 0, 2 });   // 2x^2 - 1
            Polynomial expected = new Polynomial(new double[] { -3, 8, 2, -16, 8 });// 8x^4 - 16x^3 + 2x^2 + 8x - 3

            //action
            Polynomial actual = left * right;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsMethod()
        {
            //arrange
            Polynomial left = new Polynomial(new double[] { 3, -8, 4 });    // 4x^2 - 8x + 3
            Polynomial right = new Polynomial(new double[] { 3, -8, 4 });   // 4x^2 - 8x + 3

            //action

            //assert
            Assert.IsTrue(left.Equals(right));
        }

    }
}
