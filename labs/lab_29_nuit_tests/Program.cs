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

        [TestCase(1, 2, 3)]
        [TestCase(3, 6, 9)]
        [TestCase(5, 7, 12)]
        [TestCase(2, 2, 4)]
        [TestCase(1000, 2000, 3000)]
        public void TestAdditionDemo(int a, int b, int expected)
        {
            // Arrange - setup test ready to run
            //         - create instance of test classes
            var instance = new Addition();
            // Act     - run code to get 'actual' value
            var actual = instance.AddTwoNumbers(a, b);
            // Assert  - assert.ArEqual(actual, expected);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, 2, 2)]
        public void Sum2DArrayTest(int numrows, int numcolomns, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_100_Sum_2D_Array(numrows, numcolomns);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, 2, 1)]
        [TestCase(3, 3, 3, 27)]
        [TestCase(2, 3, 4, 18)]
        public void Sum3DArrayTest(int num1, int num2, int num3, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_120_Sum_3D_Cube(num1, num2, num3);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] {1,2,3,4}, 52)]
        public void LoopsTest(int[] array, int expected)
        {
            var instance = new Basic_Tests();
            var actual = instance.Test_126_Loops(array);
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

        [TestCase(2,2,2,3)]
        public void BIDMASTest(int a, int b, int c, int expected)
        {
            var instance = new Basic_Tests();
            var actual = instance.Test_130_BIDMAS(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1,2,2,2,1,1,2,4)]
        public void BIDMAS2Test(int a, int b, int c, int d, int e, int f, int n, double expected)
        {
            var instance = new Basic_Tests();
            var actual = instance.Test_140_BIDMAS(a, b, c, d, e, f, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase('1', 1)]
        public void IntToChar(char c, int expected)
        {
            var instance = new Basic_Tests();
            var actual = instance.Test_150_Return_Integer_Of_Char(c);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("hello", 3, 108)]
        public void ASCIITest160(string input, int index, int expected)
        {
            var instance = new Basic_Tests();
            var actual = instance.Test_160_ASCII_Return_Index_Of_String(input, index);
            Assert.AreEqual(expected, actual);
        }
    }
}
