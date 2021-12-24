using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day24 : Day
    {
        List<string> Instructions;
        public Day24(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input).ToList();
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            IntMachine ALU = new IntMachine(Instructions);
            for (long i = 99999999999999; i > 11111111111110; i--)
            {
                string s = i.ToString();
                if (!s.Contains('0'))
                    if (ALU.Run(s))
                        return s;

            }
            return "Fuuu";
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public class IntMachine
        {
            Dictionary<char, long> Variables;
            List<string> Instructions;
            public IntMachine(List<string> instructions)
            {
                Instructions = new List<string>(instructions);
            }
            public bool Run(string InputString)
            {
                int InputOffset = 0;
                Variables = new Dictionary<char, long>()
                {
                    {'w',0 },
                    {'x',0 },
                    {'y',0 },
                    {'z',0 },
                };
                foreach (string s in Instructions)
                {
                    string[] Splutt = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    char c = Splutt[1][0];
                    switch (Splutt[0])
                    {
                        case "inp":
                            int InputNumber = Int32.Parse(InputString[InputOffset].ToString());
                            Variables[c] = InputNumber;
                            InputOffset++;
                            break;
                        case "add":
                            Variables[c] += GetValueFromMaybeRegister(Splutt[2]);
                            break;
                        case "mul":
                            Variables[c] *= GetValueFromMaybeRegister(Splutt[2]);
                            break;
                        case "div":
                            Variables[c] /= GetValueFromMaybeRegister(Splutt[2]);
                            break;
                        case "mod":
                            Variables[c] %= GetValueFromMaybeRegister(Splutt[2]);
                            break;
                        case "eql":
                            Variables[c] = Variables[c] == GetValueFromMaybeRegister(Splutt[2]) ? 1 : 0;
                            break;
                        default:
                            break;
                    }
                }
                return Variables['z'] == 0;
            }
            long GetValueFromMaybeRegister(string s)
            {
                if (Char.IsDigit(s.Last()))
                    return Int64.Parse(s);
                return Variables[s[0]];
            }
        }
    }
}
