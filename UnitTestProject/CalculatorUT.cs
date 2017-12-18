using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HBMPrenscia.Objects;

namespace UnitTestProject
{
    [TestClass]
    public class CalculatorUT
    {
        [TestMethod]
        [TestCategory("Basic")]
        public void TestMethod1()
        {
            var calc = new Calculator("1", "1", "+");
            calc.calculate();

            Assert.AreEqual("2", calc.getResult());

            calc.setLeft("2");
            calc.setRight("2");

            Assert.AreEqual("2", calc.getResult());

            calc.calculate();

            Assert.AreEqual("4", calc.getResult());
        }

        [TestMethod]
        [TestCategory("")]
        public void TestMethod2()
        {
            var results = new string[3];

            var calc = new Calculator("8", "2", "*");
            calc.calculate();

            results[0] = calc.getResult();
            Assert.AreEqual("16", results[0]);

            calc.setLeft("16");
            calc.calculate();

            results[1] = calc.getResult();
            Assert.AreEqual("32", results[1]);

            calc.setLeft("32");
            calc.calculate();

            results[2] = calc.getResult();
            Assert.AreEqual("64", results[2]);

            Assert.AreEqual(results[0], calc.getResult(2));
            Assert.AreEqual(results[1], calc.getResult(1));
            Assert.AreEqual(results[2], calc.getResult(0));
        }

        #region Provided Tests
        [TestMethod]
        [TestCategory("HBM Prenscia Supplied Tests")]
        public void ProvidedTests()
        {
            var calc = new Calculator("9", "1", "+");
            calc.calculate();

            Assert.AreEqual("10", calc.getResult());

            calc = new Calculator("1", "7", "-");
            calc.calculate();

            Assert.AreEqual("-6", calc.getResult());

            calc = new Calculator("8", "8", "*");
            calc.calculate();

            Assert.AreEqual("64", calc.getResult());

            calc = new Calculator("12", "3", "/");
            calc.calculate();

            Assert.AreEqual("4", calc.getResult());

        }

        [TestMethod]
        [TestCategory("HBM Prenscia Supplied Tests")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void ProvidedTests2()
        {
            var calc = new Calculator("256", "0", "+");
        }

        [TestMethod]
        [TestCategory("HBM Prenscia Supplied Tests")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void ProvidedTests3()
        {
            var calc = new Calculator(string.Empty, "423", "+");
        }

        [TestMethod]
        [TestCategory("HBM Prenscia Supplied Tests")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void ProvidedTests4()
        {
            var calc = new Calculator("foo", "14", "+");
        }
        #endregion
    }
}
