using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace aoc2020
{

/*

    day 7

*/

    public class Luggage
    {
        public List<string> rules = new List<string>();
        public List<Bag> bags = new List<Bag>();
        public Luggage(string filename) //constructor
        {
            rules = util.ReadFileLinesIntoStringList(filename);

            foreach (var r in rules)
            {
                // shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                // bright white bags contain 1 shiny gold bag.
                // faded blue bags contain no other bags.

                var ruleParts = r.Split(" bags contain ");

                var outerBagId = ruleParts[0];

                var ruleBag = new Bag();
                ruleBag.id = outerBagId;

                var innerBags = ruleParts[1];

                var innerParts = innerBags.Split(",");
                foreach (var i in innerParts)
                { 
                    // rationalize forms
                    if (!i.Contains("no other bags"))
                    {
                        var i_t = i.Trim();
                        i_t = i_t.Replace(".", "");
                        i_t = i_t.Replace("bags", "");
                        i_t = i_t.Replace("bag", "");
                        i_t = i.Trim();

                        var bagParts = i_t.Split(" ");
                        int count = 0;
                        var conv = int.TryParse(bagParts[0], out count);
                        if (!conv) throw new Exception($"bagParts parse error: {i}");

                        var bagPartId = i_t.Remove($"{count} ".Length);

                        for (int j = 0; j < count; j++)
                        {
                            var innerBag = new Bag();
                            innerBag.id = bagPartId;
                            ruleBag.CanContain.Add(innerBag);
                        }

                        var bpi = bagPartId;

                    }
                    bags.Add(ruleBag);
                }

                
            }

            var rc = bags.Count();
        }
    }

    public class Bag
    {
        public string id = "";
        public List<Bag> CanContain = new List<Bag>();
    }

    public class BagRegulationParser
    {
        public List<string> regulations = new List<string>();
        public List<string> rules = new List<string>();

        public BagRegulationParser() { }

        public BagRegulationParser(string filename) //constructor
        {
            regulations = util.ReadFileLinesIntoStringList(filename);

            foreach (var r in regulations)
            {
                // shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                // bright white bags contain 1 shiny gold bag.
                // faded blue bags contain no other bags.

                rules.Add(NormalizeRegulation(r));
            }

            System.IO.File.WriteAllLines(filename.Replace(".txt", "_00.txt"), rules);

        }       //var rc = bags.Count();

        public BagRegulationParser(string filename, int version) //constructor
        {
            regulations = util.ReadFileLinesIntoStringList(filename);

            foreach (var r in regulations)
            {
                // shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                // bright white bags contain 1 shiny gold bag.
                // faded blue bags contain no other bags.

                rules.Add(NormalizeRegulation2(r));
            }

            System.IO.File.WriteAllLines(filename.Replace(".txt", "_00.txt"), rules);

        }       //var rc = bags.Count();


        public BagRegulationParser(string filename, int version, int ov) //constructor
        {
            rules = util.ReadFileLinesIntoStringList(filename);

        }

        public int SearchTheRules(string target)
        {
            HashSet<string> bags = new HashSet<string>();
            bags.Add(target);

            var oldCount = bags.Count();

            var keepGoing = true;

            while (keepGoing)
            {
                var addedBags = new HashSet<string>();
                foreach (var b in bags)
                {
                    foreach (var r in rules)
                    {
                        var ruleparts = r.Split("=");
                        if (ruleparts.Count() == 2)
                        {
                            var leftside = ruleparts[0];
                            var rightside = ruleparts[1];

                            if (rightside.Contains(b))
                            {
                                addedBags.Add(leftside);
                            }
                        }
                    }
                }

                foreach (var ab in addedBags)
                {
                    bags.Add(ab);
                }


                if (bags.Count == oldCount) keepGoing = false;
                oldCount = bags.Count;
            }


            return (bags.Count)-1;
        }

        public string NormalizeRegulation(string regulation)
        {
            // shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
            // bright white bags contain 1 shiny gold bag.
            // faded blue bags contain no other bags.

            var ret = "";

            var ruleParts = regulation.Split(" bags contain ");

            var outerBagId = ruleParts[0];
            outerBagId = outerBagId.Replace(" ", "_");

            var innerBags = ruleParts[1];

            var rightSide = "";

            var innerParts = innerBags.Split(",");
            foreach (var i in innerParts)
            {
                // rationalize forms
                if (!i.Contains("no other bags"))
                {
                    var i_t = i.Trim();
                    i_t = i_t.Replace(".", "");
                    i_t = i_t.Replace("bags", "");
                    i_t = i_t.Replace("bag", "");
                    i_t = i_t.Trim();

                    var bagParts = i_t.Split(" ");
                    int count = 0;
                    var conv = int.TryParse(bagParts[0], out count);
                    if (!conv) throw new Exception($"bagParts parse error: {i}");

                    var bagPartId = i_t.Substring($"{count} ".Length);
                    bagPartId = bagPartId.Trim();
                    bagPartId = bagPartId.Replace(" ", "_");

                    for (int j = 0; j < count; j++)
                    {

                        rightSide = rightSide + bagPartId + "|";
                    }

                }
            }

            ret = outerBagId + "=" + rightSide;
            ret = ret.TrimEnd('|');
            return ret;
        }

        public string NormalizeRegulation2(string regulation)
        {
            // shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
            // bright white bags contain 1 shiny gold bag.
            // faded blue bags contain no other bags.

            var ret = "";

            var ruleParts = regulation.Split(" bags contain ");

            var outerBagId = ruleParts[0];
            outerBagId = outerBagId.Replace(" ", "_");

            var innerBags = ruleParts[1];

            var rightSide = "";

            var innerParts = innerBags.Split(",");
            foreach (var i in innerParts)
            {
                // rationalize forms
                if (!i.Contains("no other bags"))
                {
                    var i_t = i.Trim();
                    i_t = i_t.Replace(".", "");
                    i_t = i_t.Replace("bags", "");
                    i_t = i_t.Replace("bag", "");
                    i_t = i_t.Trim();

                    var bagParts = i_t.Split(" ");
                    int count = 0;
                    var conv = int.TryParse(bagParts[0], out count);
                    if (!conv) throw new Exception($"bagParts parse error: {i}");

                    var bagPartId = i_t.Substring($"{count} ".Length);
                    bagPartId = bagPartId.Trim();
                    bagPartId = bagPartId.Replace(" ", "_");

                    //if (count > 1) count = 1;

                    for (int j = 0; j < count; j++)
                    {

                        rightSide = rightSide + bagPartId + "|";
                    }

                }
            }

            ret = outerBagId + "=" + rightSide;
            ret = ret.TrimEnd('|');
            return ret;
        }



        public List<List<string>> BuildAllTheContents(string bag)
        {
            List<List<string>> ret = new List<List<string>>();

            var firstList = GetContents(bag);
            ret.Add(firstList);
            var keepGoing = true;
            var oldCount = 0;

            while (keepGoing)
            {
                oldCount = ret.Count();
                List<List<string>> newLists = new List<List<string>>();
                foreach (var l in ret)
                {
                    if (!l.Contains("stop_stop"))
                    {
                        foreach (var b in l)
                        {
                            var newlist = GetContents(b);
                            if (newlist.Count > 0)
                            {
                                newLists.Add(newlist);
                            }
                        }
                        l.Add("stop_stop");
                    }
                }

                foreach (var n in newLists)
                {
                    ret.Add(n);
                }
                if (ret.Count == oldCount) keepGoing = false;

            }

            return ret;
        }

        public List<string> GetContents(string bag)
        {
            var ret = new List<string>();

            foreach (var r in rules)
            {
                var ruleparts = r.Split("=");
                if (ruleparts.Count() == 2)
                {
                    var leftside = ruleparts[0];
                    var rightside = ruleparts[1];

                    if (leftside == bag)
                    {
                        var rightparts = rightside.Split("|");
                        foreach (var rp in rightparts)
                        {
                            ret.Add(rp);
                        }
                    }

                }
            }

            return ret;
        }

        public List<string> BoilRules(List<string> rules)
        {
            var ret = new List<string>();

            foreach (var r in rules)
            {
                var ruleparts = r.Split("=");
                if (ruleparts.Count() == 2)
                {
                    var leftside = ruleparts[0];
                    var rightside = ruleparts[1];
                    string newright = rightside;

                    var rightparts = rightside.Split("|");
                    foreach (var rp in rightparts)
                    {
                        foreach (var oth in rules)
                        {
                            var ruleparts2 = oth.Split("=");
                            if (ruleparts2.Count() == 2)
                            {
                                var lside = ruleparts2[0];
                                var rside = ruleparts2[1];

                                if (rp == lside && rside.Length>0)
                                {
                                    var newrule = r.Replace(rp, rside);
                                    ret.Add(newrule);
                                }
                            }
                        }

                    }
                }
                ret.Add(r);
            }

            var hs = new HashSet<string>(ret);
            ret = hs.ToList<string>();

            return ret;
        }


        public int CountOuterBags(List<string> rules,string target)
        {
            List<string> candidates = new List<string>();

            var targ = target.Replace(" ", "_");

            foreach (var r in rules)
            {
                var ruleparts = r.Split("=");
                if (ruleparts.Count() == 2)
                {
                    var leftside = ruleparts[0];
                    var rightside = ruleparts[1];
                    string newright = rightside;

                    if (rightside.Contains(targ)) candidates.Add(leftside);

                }
            }

            return (from x in candidates
                    select x).Distinct().Count();

        }
    }
}
