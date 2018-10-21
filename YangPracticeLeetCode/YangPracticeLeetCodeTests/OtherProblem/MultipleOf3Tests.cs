using Microsoft.VisualStudio.TestTools.UnitTesting;
using YangPracticeLeetCode.OtherProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.OtherProblem.Tests
{
    [TestClass()]
    public class MultipleOf3Tests
    {
        [TestMethod()]
        public void IsMultipleOf3Test__2()
        {
            int input = -2;
            Assert.AreEqual(MultipleOf3.IsMultipleOf3(input), false);
        }

        [TestMethod()]
        public void IsMultipleOf3Test_369()
        {
            int input = 369;
            Assert.AreEqual(MultipleOf3.IsMultipleOf3(input), true);
        }

        [TestMethod()]
        public void IsMultipleOf3Test__368()
        {
            int input = -368;
            Assert.AreEqual(MultipleOf3.IsMultipleOf3(input), false);
        }

        [TestMethod()]
        public void IsMultipleOf3Test_3000()
        {
            int input = 3000;
            Assert.AreEqual(MultipleOf3.IsMultipleOf3(input), true);
        }





    }
}