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
        Dictionary<int, List<Dictionary<int, bool>>> Boards;
        int ReturnValue2;
        public Day04(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfIntegerLists(Input);
            RandomNumbers = new List<int>(Instructions[0]);
            Instructions.RemoveAt(0);
            Boards = new Dictionary<int, List<Dictionary<int, bool>>>();
            List<Dictionary<int, bool>> Verticals = new List<Dictionary<int, bool>>();
            int BoardIterator = 0;

            for (int i = 0; i < Instructions.Count(); i++)
            {
                if (i % 5 == 0)
                {
                    if (Verticals.Count == 5)
                    {
                        Boards[BoardIterator].AddRange(Verticals);
                    }
                    BoardIterator++;
                    Boards.Add(BoardIterator, new List<Dictionary<int, bool>>());
                    Verticals.Clear();
                    for (int bi = 0; bi < 5; bi++)
                        Verticals.Add(new Dictionary<int, bool>());
                }
                Dictionary<int, bool> Row = new Dictionary<int, bool>();
                int ehh = 0;
                foreach (int plupp in Instructions[i])
                {
                    Row.Add(plupp, false);
                    Verticals[ehh].Add(plupp, false);
                    ehh++;
                }
                Boards[BoardIterator].Add(Row);

            }

            Boards[BoardIterator].AddRange(Verticals);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            ReturnValue2 = 0;
            List<int> BingoCount = new List<int>();

            foreach (int r in RandomNumbers)
            {
                foreach (KeyValuePair<int, List<Dictionary<int, bool>>> Board in Boards)
                {
                    if (!BingoCount.Contains(Board.Key))
                    {
                        foreach (Dictionary<int, bool> row in Board.Value)
                        {
                            if (row.ContainsKey(r))
                            {
                                row[r] = true;

                                if (!row.ContainsValue(false))
                                {
                                    if (ReturnValue == 0)
                                    {
                                        for (int i = 0; i < 5; i++)
                                        {
                                            foreach (KeyValuePair<int, bool> n in Board.Value[i])
                                            {
                                                if (!n.Value)
                                                    ReturnValue += n.Key;
                                            }
                                        }
                                        ReturnValue *= r;
                                    }
                                    if (!BingoCount.Contains(Board.Key))
                                        BingoCount.Add(Board.Key);
                                    if (BingoCount.Count == Boards.Count)
                                    {
                                        for (int i = 0; i < 5; i++)
                                        {
                                            foreach (KeyValuePair<int, bool> n in Board.Value[i])
                                            {
                                                if (!n.Value)
                                                    ReturnValue2 += n.Key;
                                            }
                                        }
                                        ReturnValue2 *= r;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = ReturnValue2;

            return ReturnValue.ToString();
        }
    }
}
