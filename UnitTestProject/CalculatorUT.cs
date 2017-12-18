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
        [TestCategory("Intermediate")]
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

            Assert.AreEqual(results[0], calc.getPreviousResult(2));
            Assert.AreEqual(results[1], calc.getPreviousResult(1));
            Assert.AreEqual(results[2], calc.getPreviousResult(0));
        }

        #region Overflow
        [TestMethod]
        [TestCategory("Advanced - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3()
        {
            var calc = new Calculator("1298237837483742", "2", "*");
            calc.calculate();
        }

        [TestMethod]
        [TestCategory("Advanced - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3A()
        {
            var calc = new Calculator("1", "2", "/");
            calc.calculate();

            calc.setLeft("7070987897987");
        }

        [TestMethod]
        [TestCategory("Advanced - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3B()
        {
            var calc = new Calculator("231", "345", "*");
            calc.calculate();

            calc.setRight("12889892309");
        }

        [TestMethod]
        [TestCategory("Advanced - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3C()
        {
            var calc = new Calculator("238727", "2387123", "*");
            calc.calculate();

            var result = calc.getResult();
        }
        #endregion

        #region Input
        [TestMethod]
        [TestCategory("Advanced - Input")]
        public void TestMethod4()
        {
            var calc = new Calculator("191", "9", "+");
            calc.calculate();

            Assert.AreEqual("200", calc.getResult());

            calc.setLeft("2");
            calc.setRight("5");
        }

        [TestMethod]
        [TestCategory("Advanced - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4A()
        {
            var calc = new Calculator(string.Empty, string.Empty, string.Empty);
        }

        [TestMethod]
        [TestCategory("Advanced - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4B()
        {
            var calc = new Calculator(null, null, null);
        }

        [TestMethod]
        [TestCategory("Advanced - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4C()
        {
            var calc = new Calculator("23", "11", "-");
            calc.calculate();

            calc.setLeft(null);
        }

        [TestMethod]
        [TestCategory("Advanced - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4D()
        {
            var calc = new Calculator("23", "11", "-");
            calc.calculate();

            calc.setRight(null);
        }
        #endregion

        #region Operator
        [TestMethod]
        [TestCategory("Advanced - Operator")]
        public void TestMethod5()
        {

        }
        #endregion

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

        [TestMethod]
        [TestCategory("Raise Exception")]
        [ExpectedException(typeof(InvalidOperatorException))]
        public void ExceptionTest()
        {
            var calc = new Calculator("1", "1", "add");
        }
    }
}
