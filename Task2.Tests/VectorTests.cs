using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Task2.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void GetLengthTest()
        {
            //arrange
            double x = 2;
            double y = 2;
            double z = 1;
            double expected = 3;

            //action
            Vector vector = new Vector(x, y, z);
            double actual = vector.GetLength();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperationAdd()
        {
            //arrange
            Vector left = new Vector(7.0, 5.0, 11.0);
            Vector right = new Vector(3.0, -5.0, 9.0);
            Vector expected = new Vector(10.0, 0.0, 20.0);

            //action
            Vector actual = left + right;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperationSubtraction()
        {
            //arrange
            Vector left = new Vector(7.0, 5.0, 11.0);
            Vector right = new Vector(3.0, -5.0, 9.0);
            Vector expected = new Vector(4.0, 10.0, 2.0);

            //action
            Vector actual = left - right;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperationMultiplication()
        {
            //arrange
            Vector left = new Vector(7.0, 5.0, 11.0);
            double right = 3.0;
            Vector expected = new Vector(21.0, 15.0, 33.0);

            //action
            Vector actual = left * right;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperationEquantity()
        {
            //arrange
            Vector left = new Vector(7.0, 5.0, 11.0);
            Vector right = new Vector(7.0, 5.0, 11);

            //action

            //assert
            Assert.IsTrue(left==right);
        }

        [TestMethod]
        public void OperationNotEquantity()
        {
            //arrange
            Vector left = new Vector(2.0, 5.0, 11.0);
            Vector right = new Vector(7.0, 5.0, 11);

            //action

            //assert
            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void OperationMoreThan()
        {
            //arrange
            Vector left = new Vector(7.0, 5.0, 11.0);
            Vector right = new Vector(2.0, 5.0, 11);

            //action

            //assert
            Assert.IsTrue(left > right);
        }

        [TestMethod]
        public void OperationLessThan()
        {
            //arrange
            Vector left = new Vector(2.0, 5.0, 11.0);
            Vector right = new Vector(7.0, 5.0, 11);

            //action

            //assert
            Assert.IsTrue(left < right);
        }

        [TestMethod]
        public void EqualsMethod()
        {
            //arrange
            Vector left = new Vector(3.0, 5.0, 9.0);
            Vector right = new Vector(3.0, 5.0, 9.0);

            //action

            //assert
            Assert.IsTrue(left.Equals(right));
        }
    }
}
