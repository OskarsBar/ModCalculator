using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCalculator;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void Test_RemoveBrackets()
        {
            string test = Solver.RemoveBrackets("12(12)12");
            Assert.AreEqual(test, "121212");
        }
        [TestMethod]
        public void Test_RemoveBrackets2()
        {
            string test = Solver.RemoveBrackets("((12(12)(5)12))");
            Assert.AreEqual(test, "1212512");
        }
        [TestMethod]
        public void Test_RemoveBrackets3()
        {
            string test = Solver.RemoveBrackets("2((1))");
            Assert.AreEqual(test, "21");
        }
        [TestMethod]
        public void Test_SumMinus()
        {
            string test = Solver.SumAndMinusFinder("3-2+1-2-4-4");
            Assert.AreEqual(test, "-8");
        }
        [TestMethod]
        public void Test_SumMinus2()
        {
            string test = Solver.SumAndMinusFinder("-44");
            Assert.AreEqual(test, "-44");
        }
        [TestMethod]
        public void Test_MultiAndDiv()
        {
            string test = Solver.MultiplyAndDivide("-3*2");
            Assert.AreEqual(test, "-6");
        }


        [TestMethod]
        public void Test_ValidBrackets()
        {
            bool test = Validation.ValidBrackets("()()()");
            Assert.AreEqual(test, true);
        }
        [TestMethod]
        public void Test_ValidBrackets2()
        {
            bool test = Validation.ValidBrackets("()44((()44())4)");
            Assert.AreEqual(test, true);
        }
        [TestMethod]
        public void Test_ValidBrackets3()
        {
            bool test = Validation.ValidBrackets("()44(()44())4)");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidBrackets4()
        {
            bool test = Validation.ValidBrackets("((1)))(");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidFormula()
        {
            bool test = Validation.ValidFormula("234*4/234-23+432");
            Assert.AreEqual(test, true);
        }
        [TestMethod]
        public void Test_ValidFormula2()
        {
            bool test = Validation.ValidFormula("+234*4/234-23+432");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidFormula3()
        {
            bool test = Validation.ValidFormula("234*4/234-23+432*");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidFormula4()
        {
            bool test = Validation.ValidFormula("234*4/234*+23+432");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidFormula5()
        {
            bool test = Validation.ValidFormula("234*4/(234*)+23+432");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidFormula6()
        {
            bool test = Validation.ValidFormula("234*4/234*(+23)+432");
            Assert.AreEqual(test, false);
        }
        [TestMethod]
        public void Test_ValidFormula7()
        {
            bool test = Validation.ValidFormula("234*4/(234+23)+432");
            Assert.AreEqual(test, true);
        }
    }
}
