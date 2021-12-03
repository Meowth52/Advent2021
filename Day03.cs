using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day03 : Day
    {
        List<bool[]> Instructions;
        public Day03(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] halfway = this.parseStringArray(Input);
            Instructions = new List<bool[]>();
            foreach (string s in halfway)
            {
                List<bool> boolList = new List<bool>();
                foreach (char c in s)
                    if (c == '1')
                        boolList.Add(true);
                    else if (c == '0')
                        boolList.Add(false);
                Instructions.Add(boolList.ToArray());
            }
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            int[] GammaCount = new int[Instructions[0].Count()];
            bool[] Gamma = new bool[Instructions[0].Count()];
            foreach (bool[] b in Instructions)
            {
                for (int i = 0; i < GammaCount.Count(); i++)
                {
                    if (b[i])
                        GammaCount[i]++;
                }
            }
            int GammaValue = 0;
            int EpsilonValue = 0;
            for (int i = 0; i < Gamma.Count(); i++)
            {
                if (GammaCount[i] > (Instructions.Count() / 2))
                {
                    Gamma[i] = true;
                    GammaValue += (int)Math.Pow(2, (Instructions[0].Count() - 1) - i);
                }
                else
                {
                    EpsilonValue += (int)Math.Pow(2, (Instructions[0].Count() - 1) - i);
                    Gamma[i] = false;
                }
            }
            ReturnValue = GammaValue * EpsilonValue;
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;
            int Oxygen = CheckLifeSupport(true);
            int Scrubb = CheckLifeSupport(false);
            ReturnValue = Oxygen * Scrubb;
            return ReturnValue.ToString();
        }
        public int CheckLifeSupport(bool wantsMajority)
        {
            int Life = 0;
            List<bool[]> RemaingInstructions = new List<bool[]>(Instructions);
            for (int i = 0; i < Instructions[0].Count(); i++)
            {
                int NumberOfTrue = 0;
                bool Keep = false;
                foreach (bool[] b in RemaingInstructions)
                {
                    if (b[i])
                        NumberOfTrue++;
                }
                if (wantsMajority)
                {
                    if (NumberOfTrue * 2 >= RemaingInstructions.Count)
                    {
                        Keep = true;
                    }
                }
                else
                {
                    if (NumberOfTrue * 2 < RemaingInstructions.Count)
                    {
                        Keep = true;
                    }
                }
                List<bool[]> NextInstructions = new List<bool[]>();
                foreach (bool[] b in RemaingInstructions)
                {
                    if (b[i] == Keep)
                        NextInstructions.Add(b);
                }
                RemaingInstructions = new List<bool[]>(NextInstructions);
                if (RemaingInstructions.Count == 1)
                    break;
            }
            for (int i = 0; i < RemaingInstructions[0].Count(); i++)
            {
                if (RemaingInstructions[0][i])
                    Life += (int)Math.Pow(2, (Instructions[0].Count() - 1) - i);
            }
            RemaingInstructions = new List<bool[]>(Instructions);
            return Life;
        }
    }
}
