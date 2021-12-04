using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day04 : Day
    {
        List<List<int>> Instructions;
        List<int> RandomNumbers;
        List<int[,]> Boards;
        public Day04(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.parseListOfIntegerLists(Input);
            RandomNumbers = new List<int>(Instructions[0]);
            for (int i = 1; i < Instructions.Count(); i++)
            {
                if (i % 5 == 1)
                    Boards.Add(new int[5, 5]); // or a dic?
            }
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
