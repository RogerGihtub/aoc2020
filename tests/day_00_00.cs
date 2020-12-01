using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*


 
*/

namespace aoc2020
{
    [TestClass]
    public class day_00_00
    {
        readonly string InputFolder = @"C:\Temp\dotnet5\aoc2020\inputs\";

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
            Console.WriteLine($"Executes once for the test class. (Optional) {context.FullyQualifiedTestClassName}");
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            Console.WriteLine($"Runs before each test. (Optional) {InputFolder}");
        }

        [TestMethod]
        public void Example1()
        {
            var expected = 0;
            var actual = -0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var expected = 1;
            var actual = -1;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Example3()
        {
            var expected = 0;
            var actual = -0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example4()
        {
            var expected = 1;
            var actual = -1;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var expected = 0;
            var actual = -0;

            Console.WriteLine(actual); //

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var expected = 0;
            var actual = -0;

            Console.WriteLine(actual); //

            Assert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Runs after each test. (Optional)
            Console.WriteLine("Runs after each test. (Optional)");
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
            Console.WriteLine("Runs once after all tests in this class are executed. (Optional)");
        }
    }
}
