using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day21 : Day
    {
        int Player1;
        int Player2;
        int Score1;
        int Score2;
        int Die;
        public Day21(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List<int> Instructions = this.ParseListOfInteger(Input);
            Player1 = Instructions[1];
            Player2 = Instructions[3];
            Score1 = 0;
            Score2 = 0;
            Die = 1;
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            int DieRolls = 0;
            while (true)
            {
                Player1 = Round(Player1);
                DieRolls += 3;
                Score1 += Player1;
                if (Score1 >= 1000)
                {
                    ReturnValue = Score2 * DieRolls;
                    break;
                }
                Player2 = Round(Player2);
                DieRolls += 3;
                Score2 += Player2;
                if (Score2 >= 1000)
                {
                    ReturnValue = Score1 * DieRolls;
                    break;
                }

            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public int Round(int player)
        {
            int Player = player;
            Player = (Player + (Die * 3 + 3));
            Player = WieredModulus(Player, 10);
            Die += 3;
            Die = WieredModulus(Die, 100);
            return Player;
        }
        public int WieredModulus(int i, int m)
        {
            int I = --i; // no zreos pls!
            int M = m;
            I %= M;
            return ++I;
        }
    }
}
