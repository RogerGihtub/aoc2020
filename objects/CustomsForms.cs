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

    public class CustomsForms
    {
        public List<string> declarations = new List<string>();
        public CustomsForms(string inputFileName) //constructor
        {
            var lines = util.ReadFileLinesIntoStringList(inputFileName);

            var s = "";

            foreach (var l in lines)
            {
                if (l.Trim().Length == 0)
                {
                    declarations.Add(s);
                    s = "";
                }
                else
                {
                    s = s + "|" + l;
                }
            }
        }

        public int YesCount(string declaration)
        {
            return (declaration.Distinct().Count())-1;
        }

        public int ImprovedYesCount(string declaration)
        {
            var arr = declaration.Split("|");

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLowerInvariant().ToCharArray();

            var ret = 0;

            foreach (var a in alpha)
            {
                var found = true;
                foreach (var d in arr)
                {
                    if (d.Length > 0)
                    {
                        if (!d.Contains(a)) found = false;
                    }
                }
                if (found) ret++;
            }

            return ret;

        }

    }
}
