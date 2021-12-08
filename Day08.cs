using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day08 : Day
    {
        string[] Instructions;
        public Day08(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.parseStringArray(Input);
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            List<string[]> strings = new List<string[]>();
            foreach (string s in Instructions)
            {
                string[] splitted = s.Split('|');
                strings.Add(splitted[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            }
            foreach (string[] s in strings)
            {
                if (s.Count() == 4)
                {
                    foreach (string ss in s)
                    {
                        if (ss.Length == 2 || ss.Length == 3 || ss.Length == 4 || ss.Length == 7)
                            ReturnValue++;
                    }
                }
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
