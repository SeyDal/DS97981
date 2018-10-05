using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {      
        [TestMethod()]
        [DeploymentItem("TestData","A2_TestData")]
        public void GradedTest_Correctness()
        {
            TestCommon.TestTools.RunLocalTest("A2",Program.Process);
        }
        [TestMethod(),Timeout(500)]
        [DeploymentItem("TestData","A2_TestData")]
        public void GradedTest_Performance()
        {
            TestCommon.TestTools.RunLocalTest("A2",Program.Process);
        }
        [TestMethod()]
        public void GradedTest_Stress()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            while (time.ElapsedMilliseconds <= 5000)
            {
                Random random_number = new Random();
                List<int> test = new List<int>(random_number.Next(2, 15));
                int count = test.Capacity;
                for (int i = 0; i < count; ++i)
                {
                    test.Add(random_number.Next(0, 50));
                }
                int result1 = Program.NaiveMaxPairwiseProduct(test);
                int result2 = Program.FastMaxPairwiseProduct(test);
                Assert.AreEqual(result1, result2);
            }
        }
    }
}