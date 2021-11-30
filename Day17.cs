using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day17 : Day
    {
        List<int> Instructions;
        public Day17(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
    }
}
