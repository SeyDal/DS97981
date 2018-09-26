﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1;
using TestCommon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(3, Program.Add(1, 2));
        }
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "TestData")]
        public void GradedTest()
        {
            TestTools.RunLocalTest(Program.Process);
        }
    }
}