using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day12 : Day
    {
        Dictionary<string, List<string>> Possibilities;
        public Day12(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] Strings = this.ParseStringArray(Input);
            Possibilities = new Dictionary<string, List<string>>();
            foreach (string s in Strings)
            {
                string[] split = s.Split('-');
                for (int i = 0; i < 2; i++)
                {
                    if (split[1 - i] != "start" && split[0 + i] != "end")
                    {
                        if (!Possibilities.ContainsKey(split[0 + i]))
                            Possibilities.Add(split[0 + i], new List<string>());
                        Possibilities[split[0 + i]].Add(split[1 - i]);
                    }
                }
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            List<List<string>> PossiblePath = new List<List<string>>();
            PossiblePath.Add(new List<string>() { "start" });
            while (PossiblePath.Count > 0)
            {
                List<List<string>> NextPaths = new List<List<string>>();
                List<string> NextList = new List<string>();
                foreach (List<string> l in PossiblePath)
                {
                    string Last = l.Last();
                    foreach (string s in Possibilities[Last])
                    {
                        if (s == "end")
                            ReturnValue++;
                        else if (Char.IsUpper(s[0]) || !l.Contains(s))
                        {
                            List<string> Next = new List<string>(l);
                            Next.Add(s);
                            NextPaths.Add(Next);
                        }
                    }
                }
                PossiblePath = new List<List<string>>(NextPaths);
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            List<(List<string> path, bool Twice)> PossiblePath = new List<(List<string> path, bool Twice)>();
            PossiblePath.Add((new List<string>() { "start" }, false));
            while (PossiblePath.Count > 0)
            {
                List<(List<string> path, bool Twice)> NextPaths = new List<(List<string> path, bool Twice)>();
                List<string> NextList = new List<string>();
                foreach ((List<string> path, bool Twice) l in PossiblePath)
                {
                    string Last = l.path.Last();
                    foreach (string s in Possibilities[Last])
                    {
                        if (s == "end")
                            ReturnValue++;
                        else if (Char.IsUpper(s[0]) || !l.path.Contains(s) || !l.Twice)
                        {
                            List<string> Next = new List<string>(l.path);
                            Next.Add(s);
                            bool NextTwice = l.Twice;
                            if (!Char.IsUpper(s[0]) && l.path.Contains(s))
                                NextTwice = true;
                            NextPaths.Add((Next, NextTwice));
                        }
                    }
                }
                PossiblePath = new List<(List<string> path, bool Twice)>(NextPaths);
            }

            return ReturnValue.ToString();
        }
    }
}
