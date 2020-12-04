using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace aoc2020
{

    /*
    byr (Birth Year)
    iyr (Issue Year)
    eyr (Expiration Year)
    hgt (Height)
    hcl (Hair Color)
    ecl (Eye Color)
    pid (Passport ID)
    cid (Country ID)

ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in

    */

    public class Passport
    {
        public string byr = "";
        public string iyr = "";
        public string eyr = "";
        public string hgt = "";
        public string hcl = "";
        public string ecl = "";
        public string pid = "";
        public string cid = "";

        public Passport(string input)
        {
        byr = "";
        iyr = "";
        eyr = "";
        hgt = "";
        hcl = "";
        ecl = "";
        pid = "";
        cid = "";

        var pieces = input.Split(" ");
            foreach (var p in pieces)
            {
                if (p.Contains(":")) 
                { 
                    var f = p.Split(":");
                    var n = f[0].Trim();
                    var v = f[1].Trim();

                    switch (n)
                    {
                        case "byr": byr = v;break;
                        case "iyr": iyr = v;break;
                        case "eyr": eyr = v;break;
                        case "hgt": hgt = v;break;
                        case "hcl":hcl = v;break;
                        case "ecl":ecl = v;break;
                        case "pid":pid = v;break;
                        case "cid": cid = v;break;

                        default:
                            throw new Exception($"{n}");
                            break;
                    }
                }
            }
        }

        public bool IsValid()
        {
            if (byr.Length == 0) return false;
            if (iyr.Length == 0) return false;
            if (eyr.Length == 0) return false;
            if (hgt.Length == 0) return false;
            if (hcl.Length == 0) return false;
            if (ecl.Length == 0) return false;
            if (pid.Length == 0) return false;
            //if (cid.Length == 0) return false;

            // improved validation

            /*
             
byr (Birth Year) - four digits; at least 1920 and at most 2002.
iyr (Issue Year) - four digits; at least 2010 and at most 2020.
eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
hgt (Height) - a number followed by either cm or in:
If cm, the number must be at least 150 and at most 193.
If in, the number must be at least 59 and at most 76.
hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
pid (Passport ID) - a nine-digit number, including leading zeroes.
cid (Country ID) - ignored, missing or not.            
             
             */

            // byr (Birth Year) - four digits; at least 1920 and at most 2002.

            int _byr = 0;
            var v1 = int.TryParse(byr, out _byr);
            if (!v1) return false;
            if (_byr < 1920) return false;
            if (_byr > 2002) return false;

            // iyr (Issue Year) - four digits; at least 2010 and at most 2020.

            int _iyr = 0;
            var v2 = int.TryParse(iyr, out _iyr);
            if (!v2) return false;
            if (_iyr < 2010) return false;
            if (_iyr > 2020) return false;

            // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            int _eyr = 0;
            var v3 = int.TryParse(eyr, out _eyr);
            if (!v3) return false;
            if (_eyr < 2020) return false;
            if (_eyr > 2030) return false;

            // hgt (Height) - a number followed by either cm or in:
            if (hgt.EndsWith("cm") || hgt.EndsWith("in"))
            {
                //good, good
            }
            else { return false; }
            // If cm, the number must be at least 150 and at most 193.
            if (hgt.EndsWith("cm"))
            {
                hgt = hgt.Replace("cm", "");
                int _hgtcm = 0;
                var v4 = int.TryParse(hgt, out _hgtcm);
                if (!v4) return false;
                if (_hgtcm < 150) return false;
                if (_hgtcm > 193) return false;
            }

            // If in, the number must be at least 59 and at most 76.
            if (hgt.EndsWith("in"))
            {
                hgt = hgt.Replace("in", "");
                int _hgtin = 0;
                var v5 = int.TryParse(hgt, out _hgtin);
                if (!v5) return false;
                if (_hgtin < 59) return false;
                if (_hgtin > 76) return false;
            }

            // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.

            if (!(hcl.StartsWith("#"))) return false;
            if (hcl.Length != 7) return false;
            hcl = hcl.Replace("#", "");
            hcl = hcl.Replace("0", "");
            hcl = hcl.Replace("1", "");
            hcl = hcl.Replace("2", "");
            hcl = hcl.Replace("3", "");
            hcl = hcl.Replace("4", "");
            hcl = hcl.Replace("5", "");
            hcl = hcl.Replace("6", "");
            hcl = hcl.Replace("7", "");
            hcl = hcl.Replace("8", "");
            hcl = hcl.Replace("9", "");
            hcl = hcl.Replace("a", "");
            hcl = hcl.Replace("b", "");
            hcl = hcl.Replace("c", "");
            hcl = hcl.Replace("d", "");
            hcl = hcl.Replace("e", "");
            hcl = hcl.Replace("f", "");
            if (hcl.Length > 0) return false;

            // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            if (ecl=="amb"|| ecl == "blu" || ecl == "brn" || ecl == "gry" || ecl == "grn" ||
                 ecl == "hzl" || ecl == "oth" )
            {
                // fine!
            }
            else
            {
                return false;
            }

            // pid (Passport ID) - a nine-digit number, including leading zeroes.
            if (pid.Length != 9) return false;
            ulong _pid = 0;
            var v6 = ulong.TryParse(pid, out _pid);
            if (!v6) return false;

            return true;
        }

    }

    public class PassportChecker
    {
        public List<Passport> passports = new List<Passport>();
        public PassportChecker(string inputFileName) //constructor
        {
            var lines = util.ReadFileLinesIntoStringList(inputFileName);

            var s = "";

            foreach (var l in lines)
            {
                if (l.Trim().Length==0)
                {
                    passports.Add(new Passport(s));
                    s = "";
                }
                else
                {
                    s = s + " " + l;
                }
            }


        }

        public int ValidCount()
        {
            var count = 0;
            foreach (var p in passports)
            {
                if (p.IsValid()) count++;
            }
            return count;
        }
    }
}
