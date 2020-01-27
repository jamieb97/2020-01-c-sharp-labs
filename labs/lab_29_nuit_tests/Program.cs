using System;
using NUnit;
using NUnit.Framework;
using lab_30_test_addition;
using lab_31_test_practice;

namespace lab_29_nuit_tests
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //create code for live demo
        //}
    }
    
    class NUnit_Tests
    {
        //create uniform testing environment - perhaps load startup info from database
        [SetUp]
        public void SetUp()
        {

        }

        [TestCase(1,2,3)]
        [TestCase(3,6,9)]
        [TestCase(5,7,12)]
        [TestCase(2,2,4)]
        [TestCase(1000,2000,3000)]
        public void TestAdditionDemo(int a, int b, int expected)
        {
            // Arrange - setup test ready to run
            //         - create instance of test classes
            var instance = new Addition();
            // Act     - run code to get 'actual' value
            var actual = instance.AddTwoNumbers(a,b);
            // Assert  - assert.ArEqual(actual, expected);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2,2,2)]
        public void Sum2DArrayTest(int numrows, int numcolomns, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_100_Sum_2D_Array(numrows, numcolomns);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2,2,2,4)]
        [TestCase(3,3,3,27)]
        [TestCase(4,4,4,96)]
        public void Sum3DArrayTest(int num1, int num2, int num3, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_120_Sum_3D_Cube(num1, num2, num3);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(10, 285)]
        [TestCase(20, 2470)]
        public void BuildArrayAndSumTest(int a, int expected)
        {
            var instance = new Basic_Tests();
            var actual = instance.Test_125_Build_Array_And_Return_Sum_Of_Squares(a);
            Assert.AreEqual(expected, actual);
        }
    }
}
