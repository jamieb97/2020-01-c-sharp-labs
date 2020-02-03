using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using lab_42_northwind_core;

namespace lab_29_nuit_tests
{
    class NorthwindTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        //tests go here 

        [Test]
        public void NorthWindDummyTest()
        {
            var instance = new Test();
            var actual = instance.Testing();
            Assert.AreEqual(actual, 91);
        }

        [Test]
        public void NorthWindDummyTest2()
        {
            var instance = new Test();
            var actual = instance.Testing_2();
            Assert.AreEqual(actual, 92);
        }
    }
}
