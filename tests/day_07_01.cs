using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

/*


 
*/

namespace aoc2020
{
    [TestClass]
    public class day_07_01
    {
        string InputFolder = @"C:\Temp\dotnet5\aoc2020\inputs\";

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
            var parser = new BagRegulationParser();

            var testreg = "bright white bags contain 1 shiny gold bag.";

            var actual = parser.NormalizeRegulation(testreg);

            var expected = "bright_white=shiny_gold";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var parser = new BagRegulationParser();

            var testreg = "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.";

            var actual = parser.NormalizeRegulation(testreg);

            var expected = "shiny_gold=dark_olive|vibrant_plum|vibrant_plum";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example22()
        {
            var parser = new BagRegulationParser();

            var testreg = "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.";

            var actual = parser.NormalizeRegulation2(testreg);

            var expected = "shiny_gold=dark_olive|vibrant_plum";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example3()
        {
            var parser = new BagRegulationParser();

            var testreg = "dotted black bags contain no other bags.";

            var actual = parser.NormalizeRegulation(testreg);

            var expected = "dotted_black=";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example4()
        {
            var parser = new BagRegulationParser(InputFolder + "input_day07_00.txt");

            //var testreg = "dotted black bags contain no other bags.";

            //var actual = parser.NormalizeRegulation(testreg);

            //var expected = "dotted_black=";
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example5()
        {
            var parser = new BagRegulationParser(InputFolder + "input_day07_00x.txt");

            var boiledOnce = parser.BoilRules(parser.rules);

            System.IO.File.WriteAllLines(InputFolder + "input_day07_00x_01.txt", boiledOnce);

            var boiledTwice = parser.BoilRules(boiledOnce);

            System.IO.File.WriteAllLines(InputFolder + "input_day07_00x_02.txt", boiledTwice);
        }

        [TestMethod]
        public void Example6() //actual example test
        {
            var parser = new BagRegulationParser(InputFolder + "input_day07_00.txt");

            var boiled = parser.BoilRules(parser.rules);

            var boilingTimes = 2;

            for (int i = 0; i < boilingTimes; i++)
            {
                boiled = parser.BoilRules(boiled);
            }

            var target = "shiny gold";

            var actual = parser.CountOuterBags(boiled, target);
            var expected = 4;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Example66() //actual example test
        {
            var parser = new BagRegulationParser(InputFolder + "input_day07_00.txt",2);

            var boiled = parser.BoilRules(parser.rules);

            var boilingTimes = 2;

            for (int i = 0; i < boilingTimes; i++)
            {
                boiled = parser.BoilRules(boiled);
            }

            var target = "shiny gold";

            var actual = parser.CountOuterBags(boiled, target);
            var expected = 4;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Example666() //actual example test
        {
            InputFolder = InputFolder + @"day07\";
            var parser = new BagRegulationParser(InputFolder + "input_day07_02_000.txt", 2);

            System.IO.File.WriteAllLines(InputFolder + "input_day07_02_000_00.txt", parser.rules);

        }

        [TestMethod]
        public void Example8() //part 2
        {
            InputFolder = InputFolder + @"day07\";
            var parser = new BagRegulationParser(InputFolder + "input_day07_02_000_00.txt", 2, 3);

            var shiny_gold_list = parser.GetContents("shiny_gold");

            var c = shiny_gold_list.Count;
        }

        [TestMethod]
        public void Example9() //part 2
        {
            InputFolder = InputFolder + @"day07\";
            var parser = new BagRegulationParser(InputFolder + "input_day07_02_000_00.txt", 2, 3);

            //var shiny_gold_list = parser.GetContents("shiny_gold");
            var level_2_list = parser.BuildAllTheContents("shiny_gold");

            var c = level_2_list.Count;
        }


        [TestMethod]
        public void Example7() //actual example test
        {
            var parser = new BagRegulationParser(InputFolder + "input_day07_00.txt");

            var boiled = parser.BoilRules(parser.rules);

            var oldBoiledCount = 0;

            do
            {
                oldBoiledCount = boiled.Count;
                boiled = parser.BoilRules(boiled);
            } while (boiled.Count != oldBoiledCount);

            var target = "shiny gold";

            var actual = parser.CountOuterBags(boiled, target);
            var expected = 4;

            Console.WriteLine($"{boiled.Count}");

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [Timeout(3600000)]
        public void Part1()
        {
            InputFolder = InputFolder + @"day07\";
            var parser = new BagRegulationParser(InputFolder + "input_day07_01_00.txt", 2, 3);

            //var boiled = parser.BoilRules(parser.rules);

            //System.IO.File.WriteAllLines(InputFolder + "input_day07_01_02.txt", boiled);

            /*
            var oldBoiledCount = 0;

            do
            {
                oldBoiledCount = boiled.Count;
                boiled = parser.BoilRules(boiled);
            } while (boiled.Count != oldBoiledCount);
            */

            var target = "shiny_gold";



            //var actual = parser.CountOuterBags(boiled, target);
            var actual = parser.SearchTheRules(target);
            var expected = 131;

            // 1978, 10
            // 17800, 44
            // 1820900, 125

            //Console.WriteLine($"{boiled.Count}");
            Console.WriteLine($"{actual}");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            InputFolder = InputFolder + @"day07\";
            var parser = new BagRegulationParser(InputFolder + "input_day07_01_00.txt", 2, 3);
            //the input file has been gently pre-processed:
            // original: shiny gold bags contain 2 dark red bags.
            // cooked: shiny_gold=dark_red|dark_red

            var target = "shiny_gold";
            var bigList = parser.BuildAllTheContents(target); // a list of lists

            var actual = bigList.Count - 1; //why does this work?

            Console.WriteLine(actual);

            var expected = 11261;

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
