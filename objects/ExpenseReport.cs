using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic; // Financial class -- https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.financial?view=net-5.0

namespace aoc2020
{

    /*

Day 01

Before you leave, the Elves in accounting just need you to fix your expense report 
(your puzzle input); apparently, something isn't quite adding up.

Specifically, they need you to find the two entries that sum to 2020 and 
then multiply those two numbers together.

[part 2] find three numbers in your expense report that meet the same criteria.

    */

    public class ExpenseReport
    {
        // there's no built-in (or library) data type for Currency or Money, so we
        // might as well fit something to the data, and ushort fits.

        // what Collections data type shall we use?  List<> is obvious, of course.
        // Then there's ImmutableArray (and ImmutableList) -- see  https://devblogs.microsoft.com/dotnet/please-welcome-immutablearrayt/
        // There's probably no good reason right now not to leave it as List

        private readonly List<ushort> Entries = new List<ushort>();


        // https://en.wikipedia.org/wiki/Cartesian_product
        // In mathematics, specifically set theory, the Cartesian product of two sets A and B, 
        // denoted A × B, is the set of all ordered pairs (a, b) where a is in A and b is in B.

        private readonly List<Tuple<ushort, ushort>> Squares = new List<Tuple<ushort, ushort>>();

        private readonly List<Tuple<ushort, ushort, ushort>> Cubes = new List<Tuple<ushort, ushort, ushort>>();


        public ExpenseReport(string inputFileName) //constructor
        {
            Entries = util.ReadFileLinesIntoUShortList(inputFileName);
        }

        public void GenerateCartesianSquares()
        {
            var squares = (from x in Entries
                     from y in Entries
                     select new { x, y });

            foreach (var sq in squares)
            {
                Squares.Add(new Tuple<ushort, ushort>(sq.x, sq.y));
            }

            /*
            Squares = (List<Tuple<ushort, ushort>>)
                        (from x in Entries
                        from y in Entries
                        select new { x, y }); */
        }

        public void GenerateCartesianCubes()
        {
            var cubes = (from x in Entries
                         from y in Entries
                         from z in Entries
                         select new { x, y, z });

            foreach (var c in cubes)
            {
                Cubes.Add(new Tuple<ushort, ushort, ushort>(c.x, c.y, c.z));
            }

            /*Cubes = (List<Tuple<ushort, ushort, ushort>>)
                        (from x in Entries
                         from y in Entries
                         from z in Entries
                         select new { x, y, z }); */
        }


        // https://en.wikipedia.org/wiki/Norm_(mathematics)#Taxicab_norm_or_Manhattan_norm

        public static ushort ManhattanNorm(Tuple<ushort, ushort> point)
        {
            return (ushort)(point.Item1 + point.Item2);
        }

        public static ushort ManhattanNorm(Tuple<ushort, ushort, ushort> point)
        {
            return (ushort)(point.Item1 + point.Item2 + point.Item3);
        }

        public Tuple<ushort, ushort> GetSquareByNorm(ushort norm)
        {
            if (Squares.Count == 0) GenerateCartesianSquares();

            foreach (var square in Squares)
            {
                if (ManhattanNorm(square) == norm) return square;
            }
            throw new Exception($"Could not find square with target norm {norm}");
        }

        public Tuple<ushort, ushort, ushort> GetCubeByNorm(ushort norm)
        {
            if (Cubes.Count == 0) GenerateCartesianCubes();

            foreach (var cube in Cubes)
            {
                if (ManhattanNorm(cube) == norm) return cube;
            }
            throw new Exception($"Could not find cube with target norm {norm}");
        }

        public static uint Area(Tuple<ushort, ushort> square)
        {
            return (uint)(square.Item1 * square.Item2);
        }

        public static uint Volume(Tuple<ushort, ushort, ushort> cube)
        {
            return (uint)(cube.Item1 * cube.Item2 * cube.Item3);
        }

    }

}
