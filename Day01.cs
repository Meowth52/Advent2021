using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day01 : Day
    {
        List<int> Instructions;
        public Day01(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfInteger(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            int Previous = 1000000;
            foreach (int i in Instructions)
            {
                if (i > Previous)
                    ReturnValue++;
                Previous = i;
            }

            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = -1;
            int Previous = 0;
            int Previouser = 1000000;
            int Previousest = 1000000;
            foreach (int i in Instructions)
            {
                if (i > Previousest)
                    ReturnValue++;
                Previousest = Previouser;
                Previouser = Previous;
                Previous = i;
            }
            return ReturnValue.ToString();
        }
    }
}
