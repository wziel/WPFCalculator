using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model.Operations;

namespace WPFCalcZielinski.Tests.Model
{
    [TestClass]
    public class Operations
    {
        [TestMethod]
        public void Add()
        {
            var result = new AddOperation().Perform(10, 5);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void ChangeSign()
        {
            var result = new ChangeSignOperation().Perform(10);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void Clear()
        {
            var result = new ClearOperation().Perform(10);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Divide()
        {
            var expected = (double)10 / 3;
            var result = new DivideOperation().Perform(10, 3);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_Exception()
        {
            new DivideOperation().Perform(10, 0);
        }

        [TestMethod]
        public void Multiply()
        {
            var result = new MultiplyOperation().Perform(10, 5);
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void NoOperation()
        {
            var result = new NoOperation().Perform(10);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Percentage()
        {
            var result = new PercentageOperation().Perform(10);
            Assert.AreEqual(0.1, result);
        }

        [TestMethod]
        public void Sqrt()
        {
            var result = new SqrtOperation().Perform(10);
            Assert.AreEqual(Math.Sqrt(10), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Sqrt_Exception()
        {
            var result = new SqrtOperation().Perform(-10);
        }

        [TestMethod]
        public void Subtract()
        {
            var result = new SubtractOperation().Perform(10, 4);
            Assert.AreEqual(6, result);
        }
    }
}
