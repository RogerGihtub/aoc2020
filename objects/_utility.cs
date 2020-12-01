using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{

/*



*/

    public static class util
    {

        public static List<ushort> ReadFileLinesIntoUShortList(string inputFileName)
        {
            var ret = new List<ushort>();
            var lines = System.IO.File.ReadAllLines(inputFileName);

            foreach (var s in lines)
            {
                var success = ushort.TryParse(s, out ushort n);
                if (!success) throw new Exception($"ushort.TryParse() failed with {s}");
                ret.Add(n);
            }
            return ret;
        }

        /* 
        public static List<ulong> ReadFileLinesIntoULongList(string inputFileName) 
        {
            var ret = new List<ulong>();
            var lines = System.IO.File.ReadAllLines(inputFileName);
            var lineCount = lines.Length;

            ulong n = 0;
            foreach (var s in lines)
            {
                ulong.TryParse(s, out n);
                ret.Add(n);
            }
            return ret;
        }

        public static List<int> ReadFileLinesIntoIntList(string inputFileName)
        {
            var ret = new List<int>();
            var lines = System.IO.File.ReadAllLines(inputFileName);
            var lineCount = lines.Length;

            int n = 0;
            foreach (var s in lines)
            {
                int.TryParse(s, out n);
                ret.Add(n);
            }
            return ret;
        }

        public static List<int> ReadFileCSVIntoIntList(string inputFileName)
        {
            var ret = new List<int>();
            var lines = System.IO.File.ReadAllLines(inputFileName);
            var lineCount = lines.Length;

            int n = 0;
            foreach (var s in lines)
            {
                ret = ReadCommaSeparatedNumbersIntoIntList(s);
            }
            return ret;
        }

        public static List<int> ReadCommaSeparatedNumbersIntoIntList(string csv)
        {
            var ret = new List<int>();
            var lines = csv.Split(',');
            var lineCount = lines.Length;

            int n = 0;
            foreach (var s in lines)
            {
                int.TryParse(s, out n);
                ret.Add(n);
            }
            return ret;
        }

        public static bool IsCommaSeparated(string arg)
        {
            return arg.Contains(',');
        }
        */

    }
}
