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
        (int Max, int Min) XLimits;
        (int Max, int Min) YLimits;
        public Day17(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List<int> Instructions = this.ParseListOfInteger(Input);
            XLimits = (Instructions[0], Instructions[1]);
            YLimits = (Instructions[2], Instructions[3]);
            ;
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public int MaxX((int Max, int Min) Limits)
        {
            int ReturnValue = 0;
            while ()
            {
                int x = ReturnValue;
                while ()
                {

                }
            }
            return ReturnValue;
        }
        public int MaxY((int Max, int Min) Limits)
        {
            int ReturnValue = 0;
            while ()
            {
                int y = ReturnValue;
                while ()
                {

                }
            }
            return ReturnValue;
        }
    }
}
