using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day07 : Day
    {
        List<int> Instructions;
        public Day07(string _input) : base(_input)
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
            int ReturnValue = 1000000;
            for (int i = 0; i < Instructions.Count(); i++)
            {
                int Fuel = 0;
                for (int ii = 0; ii < Instructions.Count(); ii++)
                {
                    if (i != ii)
                        Fuel += Math.Abs(Instructions[i] - Instructions[ii]);

                }
                if (Fuel < ReturnValue)
                    ReturnValue = Fuel;
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 1000000000;
            for (int i = 0; i < Instructions.Count(); i++)
            {
                int Fuel = 0;
                for (int ii = 0; ii < Instructions.Count(); ii++)
                {
                    if (i != ii)
                        Fuel += fib(Math.Abs(Instructions[i] - Instructions[ii]));

                }
                if (Fuel < ReturnValue)
                    ReturnValue = Fuel;
            }

            return ReturnValue.ToString();
        }
        public int fib(int input)
        {
            int ReturnValue = 0;
            for (int i = 0; i <= input; i++)
                ReturnValue += i;
            return ReturnValue;
        }
    }
}
