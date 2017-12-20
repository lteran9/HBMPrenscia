using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HBMPrenscia.Objects;

namespace UnitTestProject
{
    [TestClass]
    public class CalculatorUT
    {
        [TestMethod]
        [TestCategory("Calculator")]
        public void TestMethod1()
        {
            /// Basic
            var calc = new Calculator("1", "1", "+");
            calc.Calculate();

            Assert.AreEqual("2", calc.GetResult());

            calc.SetLeft("2");
            calc.SetRight("2");

            Assert.AreEqual("2", calc.GetResult());

            calc.Calculate();

            Assert.AreEqual("4", calc.GetResult());

            /// Intermediate
            var results = new string[3];

            calc = new Calculator("8", "2", "*");
            calc.Calculate();

            results[0] = calc.GetResult();
            Assert.AreEqual("16", results[0]);

            calc.SetLeft("16");
            calc.Calculate();

            results[1] = calc.GetResult();
            Assert.AreEqual("32", results[1]);

            calc.SetLeft("32");
            calc.Calculate();

            results[2] = calc.GetResult();
            Assert.AreEqual("64", results[2]);

            Assert.AreEqual(results[0], calc.GetPreviousResult(2));
            Assert.AreEqual(results[1], calc.GetPreviousResult(1));
            Assert.AreEqual(results[2], calc.GetResult());

            /// Advanced
            calc = new Calculator("56", "24", "+");
            calc.Calculate();

            calc.SetLeft("4");
            calc.SetRight("9");
            calc.Calculate();

            calc.SetLeft("13");
            calc.SetRight("2");
            calc.Calculate();

            calc.SetLeft("43");
            calc.SetRight("5");
            calc.Calculate();

            calc.SetLeft("1");
            calc.SetRight("1");
            calc.Calculate();

            calc.SetLeft("29");
            calc.SetRight("78");
            calc.Calculate();

            calc.SetLeft("34");
            calc.SetRight("63");
            calc.Calculate();

            calc.SetLeft("75");
            calc.SetRight("12");
            calc.Calculate();

            calc.SetLeft("93");
            calc.SetRight("56");
            calc.Calculate();

            calc.SetLeft("54");
            calc.SetRight("4");
            calc.Calculate();

            Assert.AreEqual("58", calc.GetResult());
            Assert.AreEqual("149", calc.GetPreviousResult(1));
            Assert.AreEqual("87", calc.GetPreviousResult(2));
            Assert.AreEqual("97", calc.GetPreviousResult(3));
            Assert.AreEqual("107", calc.GetPreviousResult(4));
            Assert.AreEqual("2", calc.GetPreviousResult(5));
            Assert.AreEqual("48", calc.GetPreviousResult(6));
            Assert.AreEqual("15", calc.GetPreviousResult(7));
            Assert.AreEqual("13", calc.GetPreviousResult(8));
            Assert.AreEqual("80", calc.GetPreviousResult(9));
        }

        [TestMethod]
        [TestCategory("Calculator")]
        public void TestMethod2()
        {
            
        }

        #region Overflow
        [TestMethod]
        [TestCategory("Calculator - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3()
        {
            var calc = new Calculator("1298237837483742", "2", "*");
            calc.Calculate();
        }

        [TestMethod]
        [TestCategory("Calculator - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3A()
        {
            var calc = new Calculator("1", "2", "/");
            calc.Calculate();

            calc.SetLeft("7070987897987");
        }

        [TestMethod]
        [TestCategory("Calculator - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3B()
        {
            var calc = new Calculator("231", "345", "*");
            calc.Calculate();

            calc.SetRight("12889892309");
        }

        [TestMethod]
        [TestCategory("Calculator - Overflow")]
        [ExpectedException(typeof(ResultOverflowException))]
        public void TestMethod3C()
        {
            var calc = new Calculator("238727", "2387123", "*");
            calc.Calculate();

            var result = calc.GetResult();
        }
        #endregion

        #region Input
        [TestMethod]
        [TestCategory("Calculator - Input")]
        public void TestMethod4()
        {
            var calc = new Calculator("191", "9", "+");
            calc.Calculate();

            Assert.AreEqual("200", calc.GetResult());

            calc.SetLeft("2");
            calc.SetRight("5");

            /// No exception expected
        }

        [TestMethod]
        [TestCategory("Calculator - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4A()
        {
            var calc = new Calculator(string.Empty, string.Empty, string.Empty);
        }

        [TestMethod]
        [TestCategory("Calculator - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4B()
        {
            var calc = new Calculator(null, null, "+");
        }

        [TestMethod]
        [TestCategory("Calculator - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4C()
        {
            var calc = new Calculator("23", "11", "-");
            calc.Calculate();

            calc.SetLeft(null);
        }

        [TestMethod]
        [TestCategory("Calculator - Input")]
        [ExpectedException(typeof(InvalidParameterException))]
        public void TestMethod4D()
        {
            var calc = new Calculator("23", "11", "-");
            calc.Calculate();

            calc.SetRight(null);
        }

        [TestMethod]
        [TestCategory("Calculator - Input")]
        [ExpectedException(typeof(InvalidOperatorException))]
        public void TestMethod4E()
        {
            var calc = new Calculator("50", "50", null);
        }

        [TestMethod]
        [TestCategory("Calculator - Input")]
        [ExpectedException(typeof(InvalidOperatorException))]
        public void TestMethod4F()
        {
            var calc = new Calculator("50", "50", "add");
        }
        #endregion

        #region Provided Tests
        [TestMethod]
        [TestCategory("HBM Prenscia Supplied Tests")]
        public void ProvidedTests()
        {
            var calc = new Calculator("9", "1", "+");
            calc.Calculate();

            Assert.AreEqual("10", calc.GetResult());

            calc = new Calculator("1", "7", "-");
            calc.Calculate();

            Assert.AreEqual("-6", calc.GetResult());

            calc = new Calculator("8", "8", "*");
            calc.Calculate();

            Assert.AreEqual("64", calc.GetResult());

            calc = new Calculator("12", "3", "/");
            calc.Calculate();

            Assert.AreEqual("4", calc.GetResult());
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

        #region Concept
        [TestMethod]
        [TestCategory("Raise Exception")]
        [ExpectedException(typeof(InvalidOperatorException))]
        public void ExceptionTest()
        {
            var calc = new Calculator("1", "1", "add");
        }
        #endregion
    }
}
