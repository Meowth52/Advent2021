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
        List<int> Instructions;
        int Player1;
        int Player2;
        int Score1;
        int Score2;
        int Die;
        public Day21(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfInteger(Input);
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
            int OPlayer1 = Instructions[1];
            int OPlayer2 = Instructions[3];
            long Player1Wins = 0;
            long Player2Wins = 0;
            List<List<byte>> Dice = new List<List<byte>>();
            Dice.Add(new List<byte>());
            Dictionary<int, int> Odds = new Dictionary<int, int>()
            {
                {3,1 },
                {4,3 },
                {5,6 },
                {6,7 },
                {7,6 },
                {8,3 },
                {9,1 }
            };
            while (Dice.Count > 0)
            {
                List<List<byte>> NextDice = new List<List<byte>>();
                foreach (List<byte> QuantumDirac in Dice)
                {
                    for (byte ii = 3; ii <= 9; ii++)
                    {
                        List<byte> NextList = new List<byte>(QuantumDirac);
                        NextList.Add(ii);
                        Player1 = OPlayer1;
                        Player2 = OPlayer2;
                        Score1 = 0;
                        Score2 = 0;
                        bool win = false;
                        for (int schmii = 0; schmii < NextList.Count; schmii++)
                        {
                            if (schmii % 2 == 0)
                            {
                                Player1 = DiracRound(Player1, NextList[schmii]);
                                Score1 += Player1;
                                if (Score1 >= 21)
                                {
                                    int scoresum = 1;
                                    for (int n = 0; n < NextList.Count; n++)
                                        if (n % 2 == 0)
                                            scoresum *= Odds[NextList[n]];
                                    Player1Wins += scoresum;
                                    win = true;
                                    break;
                                }
                            }
                            else
                            {

                                Player2 = DiracRound(Player2, NextList[schmii]);
                                Score2 += Player2;
                                if (Score2 >= 21)
                                {
                                    int scoresum = 1;
                                    for (int n = 0; n < NextList.Count; n++)
                                        if (n % 2 == 1)
                                            scoresum *= Odds[NextList[n]];
                                    Player2Wins += scoresum;
                                    win = true;
                                    break;
                                }
                            }
                        }
                        if (!win)
                            NextDice.Add(NextList);
                    }
                }
                Dice = new List<List<byte>>(NextDice);
            }
            return Math.Max(Player1Wins, Player2Wins).ToString();
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
        public int DiracRound(int player, int roll)
        {
            int Player = player;
            Player += roll;
            Player = WieredModulus(Player, 10);
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
