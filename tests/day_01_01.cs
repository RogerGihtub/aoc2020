using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 
*/

namespace aoc2020
{
    [TestClass]
    public class day_01_01
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
            Console.WriteLine("Runs before each test. (Optional)");
        }

        [TestMethod]
        public void Example1()
        {
            var expenses = new ExpenseReport(InputFolder + "input_day01_00.txt");

            ushort targetSum = 2020;

            var pair = expenses.GetSquareByNorm(targetSum);

            var actual = ExpenseReport.Area(pair);

            uint expected = 514579;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var expenses = new ExpenseReport(InputFolder + "input_day01_01.txt");

            ushort targetSum = 2020;

            var pair = expenses.GetSquareByNorm(targetSum);

            var actual = ExpenseReport.Area(pair);

            Console.WriteLine(actual);
            
            uint expected = 158916;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var expenses = new ExpenseReport(InputFolder + "input_day01_01.txt");

            ushort targetSum = 2020;

            var triplet = expenses.GetCubeByNorm(targetSum);

            var actual = ExpenseReport.Volume(triplet);

            Console.WriteLine(actual);

            uint expected = 165795564;
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
