using HBMPrenscia.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class AltCalculatorUT
    {
        [TestMethod]
        [TestCategory("AltCalc")]
        public void TestMethod1()
        {
            string result1 = AltCalculator.Calculate("3 + 4 * 2 - 1");

            Assert.AreEqual("10", result1);

            string result2 = AltCalculator.Calculate("4 / 2 + 1");

            Assert.AreEqual("3", result2);

            string result3 = AltCalculator.Calculate("2 + 4 / 3 * 10");
            /// INT division of 4/3 gives 1
            Assert.AreEqual("12", result3);

            AltCalculator.Clear();
        }

        [TestMethod]
        [TestCategory("AltCalc")]
        public void TestMethod2()
        {
            var result1 = AltCalculator.Calculate("1 + 1 + 1 + 1 + 1");

            Assert.AreEqual("5", result1);

            var result2 = AltCalculator.Calculate("2 * 2 * 2");

            Assert.AreEqual("8", result2);

            var result3 = AltCalculator.Calculate("1000 / 50");

            Assert.AreEqual("20", result3);

            Assert.AreEqual(result1, AltCalculator.GetPreviousResult(0));
            Assert.AreEqual(result2, AltCalculator.GetPreviousResult(1));
            Assert.AreEqual(result3, AltCalculator.GetPreviousResult(2));
            Assert.AreEqual(string.Empty, AltCalculator.GetPreviousResult(3));

            AltCalculator.Clear();
        }

        [TestMethod]
        [TestCategory("AltCalc")]
        public void TestMethod3()
        {

        }
    }
}
