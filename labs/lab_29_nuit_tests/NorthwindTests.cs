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
        [Test]
        public void ProductCountTest()
        {
            var instance = new Test();
            var actual = instance.Testing_4();
            Assert.AreEqual(actual, 77);
        }

        [Test]
        public void ListCount()
        {
            var instance = new Test();
            var actual = instance.Testing_5();
            Assert.AreEqual(actual, 3);
        }
        [Test]
        public void ListCount2()
        {
            var instance = new Test();
            var actual = instance.Testing_6();
            Assert.AreEqual(actual, 17);
        }
        [Test]
        public void PeopleInCityTest()
        {
            var instance = new Test();
            var actual = instance.Testing_7();
            Assert.AreEqual(actual, 6);
        }

        [Test]
        public void CustomersInCountryTest()
        {
            var instance = new Test();
            var actual = instance.Testing_8();
            Assert.AreEqual(actual, 8);
        }
    }
}
