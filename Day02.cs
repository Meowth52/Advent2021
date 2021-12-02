using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day02 : Day
    {
        string[] Instructions;
        List<(char Direction, int Amount)> Commands;
        public Day02(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.parseStringArray(Input);
            Commands = new List<(char Direction, int Amount)>();
            foreach (string s in Instructions)
            {
                char Direction = s[0];
                int Amount = Int32.Parse(Regex.Match(s, @"-?\d+").Value);
                Commands.Add((Direction, Amount));
            }
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            (int x, int y) Position = (0, 0);
            foreach ((char Direction, int Amount) c in Commands)
            {
                switch (c.Direction)
                {
                    case 'f':
                        Position.x += c.Amount;
                        break;
                    case 'u':
                        Position.y -= c.Amount;
                        break;
                    case 'd':
                        Position.y += c.Amount;
                        break;
                    default:
                        break;
                }
            }
            ReturnValue = Position.x * Position.y;
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;
            (int x, int y) Position = (0, 0);
            int Aim = 0;
            foreach ((char Direction, int Amount) c in Commands)
            {
                switch (c.Direction)
                {
                    case 'f':
                        Position.x += c.Amount;
                        Position.y += c.Amount * Aim;
                        break;
                    case 'u':
                        Aim -= c.Amount;
                        break;
                    case 'd':
                        Aim += c.Amount;
                        break;
                    default:
                        break;
                }
            }
            ReturnValue = Position.x * Position.y;

            return ReturnValue.ToString();
        }
    }
}
