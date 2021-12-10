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
        public Day10(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.parseStringArray(Input).ToList();
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            foreach (string s in Instructions)
            {
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
                            break;
                        }
                    }
                    else
                    {
                        Tracker.Add(c);
                    }
                }
                ;
            }
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
    }
}
