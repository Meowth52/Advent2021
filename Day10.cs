using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day10 : Day
    {
        List<string> Instructions;
        List<string> LessWrong;
        public Day10(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input).ToList();
            LessWrong = new List<string>();
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            foreach (string s in Instructions)
            {
                bool StringOk = true;
                Dictionary<char, int> Points = new Dictionary<char, int>()
                {
                    {')',3 },
                    {']',57 },
                    {'}',1197 },
                    { '>',25137 }
                };
                Dictionary<char, char> Paranthes = new Dictionary<char, char>()
                {
                    {')','(' },
                    {']','[' },
                    {'}','{' },
                    {'>','<' }
                };
                List<char> Tracker = new List<char>();
                foreach (char c in s)
                {
                    if (Paranthes.ContainsKey(c))
                    {
                        if (Tracker.Last() == Paranthes[c])
                            Tracker.RemoveAt(Tracker.Count - 1);
                        else
                        {
                            ReturnValue += Points[c];
                            StringOk = false;
                            break;
                        }
                    }
                    else
                    {
                        Tracker.Add(c);
                    }
                }

                if (StringOk)
                {
                    char[] Meh = Tracker.ToArray();
                    Array.Reverse(Meh);
                    LessWrong.Add(new string(Meh));
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            long ReturnValue = 0;
            Dictionary<char, int> Points = new Dictionary<char, int>()
            {
                {'(',1 },
                {'[',2 },
                {'{',3 },
                { '<',4 }
            };
            List<long> PointList = new List<long>();
            foreach (string s in LessWrong)
            {
                long Point = 0;
                foreach (char c in s)
                {
                    Point *= 5;
                    Point += Points[c];
                }
                PointList.Add(Point);
            }
            PointList.Sort();
            ReturnValue = PointList[PointList.Count / 2];
            return ReturnValue.ToString();
        }
    }
}
