using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day06 : Day
    {
        List<int> Instructions;
        Dictionary<int, long> GroupedFish;
        long ReturnValue2;
        public Day06(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.parseListOfInteger(Input);
            GroupedFish = new Dictionary<int, long>();
            ReturnValue2 = 0;
            for (int i = 0; i < 10; i++)
            {
                GroupedFish.Add(i, Instructions.Count(x => x == i));
            }
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            long ReturnValue = 0;
            for (int i = 0; i < 256; i++)
            {
                long Zeros = GroupedFish[0];
                for (int schmi = 0; schmi < 9; schmi++)
                {
                    GroupedFish[schmi] = GroupedFish[schmi + 1];
                }
                GroupedFish[6] += Zeros;
                GroupedFish[8] = Zeros;
                if (i == 79)
                    ReturnValue = GroupedFish.Values.Sum();
            }
            ReturnValue2 = GroupedFish.Values.Sum();
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            long ReturnValue = ReturnValue2;

            return ReturnValue.ToString();
        }
    }
}
