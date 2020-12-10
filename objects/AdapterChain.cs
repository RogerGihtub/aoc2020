using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace aoc2020
{

/*



*/

    public class AdapterChain
    {
        public List<ushort> Adapters = new List<ushort>();
        public string StrListDiff = "";
        public List<ushort> Shortest = new List<ushort>();
        public AdapterChain (string inputFileName) //constructor
        {
            Adapters = util.ReadFileLinesIntoUShortList(inputFileName);
            Adapters.Add(0);
            Adapters.Sort();
            ushort max = Adapters[Adapters.Count - 1];
            max = (ushort)(max + (ushort)3);
            Adapters.Add(max);
        }

        public int AdjacentDifference(int index)
        {
            return Adapters[index + 1] - Adapters[index];
        }

        public int AdjacentDifference(List<ushort> adapts,int index)
        {
            return adapts[index + 1] - adapts[index];
        }

        public string BuildStringListOfDiffrences()
        {
            var length = Adapters.Count - 1;
            for (int i = 0; i < length; i++)
            {
                var ad = AdjacentDifference(i);
                string ads = ad.ToString();
                StrListDiff+=(ads);
            }
            return StrListDiff;
        }



        public bool isValid(List<ushort> adapts)
        {
            var length = adapts.Count - 1;
            for (int i = 0; i < length; i++)
            {
                var ad = AdjacentDifference(adapts,i);
                if (ad > 3) return false;
            }
            return true;
        }

        public int CountCharInList(string target)
        {
            return (StrListDiff.Count(x => x == char.Parse(target)))+1;
        }

        public List<ushort> TryToShorten(List<ushort> adapts, int index)
        {
            if (index >= adapts.Count()-1) return adapts;

            List<ushort> ret = new List<ushort>(adapts);
                
                ret.RemoveAt(index);

            if (isValid(ret)) return ret;

            return adapts;
        }

        public void BuildShortestList()
        {
            Shortest = new List<ushort>(Adapters);

            var keepGoing = true;

            while (keepGoing)
            {
                var oldLength = Shortest.Count();
                TryToShortenShortest();
                var newLength = Shortest.Count();
                if (oldLength == newLength) keepGoing = false;
            }
        }

        public void TryToShortenShortest()
        {
            var length = Shortest.Count()-1;

            for (int i = 1; i < length; i++) // don't remove first node
            {
                var newList = TryToShorten(Shortest, i);

                if (newList.Count<Shortest.Count)
                {
                    Shortest.Clear();
                    Shortest = new List<ushort>(newList);
                }
            }

        }

        public int ListDifference()
        {
            return (Adapters.Count - Shortest.Count);
        }

        public BigInteger FragmentDiffs(string diffs)
        {
            if (diffs == "") diffs = StrListDiff;
            var ret = diffs.Split('3');

            BigInteger lengths = 1;

            foreach (var r in ret)
            {
                var l = r.Length;
                BigInteger c = FigureCombinations(l);//util.intFactorial(l);
                lengths = lengths * c;
            }

            return lengths;
        }

        public int FigureCombinations(int length)
        {
            //"1313311113113111131311313111131111331111311113111133111311311113111131111311311113111131111"

            if (length == 0) return 1; //33 //0,3,6
            if (length == 1) return 1; //313 //0,3,4,7
            if (length == 2) return 2; //3113 //0,3,4,5,8 : [0,3,4,5,8] [0,3,5,8]

            //31113 //0,3,4,5,6,9
            // [0,3,4,5,6,9] [0,3,5,6,9] [0,3,6,9] [0,3,4,6,9]
            if (length == 3) return 4;

            //311113 //0,3,4,5,6,7,10
            // [0,3,4,5,6,7,10]
            // [0,3,5,6,7,10]
            // [0,3,4,6,7,10] 
            // [0,3,4,5,7,10]
            // [0,3,6,7,10] 
            // [0,3,5,7,10]
            // [0,3,4,7,10]

            if (length == 4) return 7;

            throw new Exception("Too Long! " + length);
        }


    }
}
