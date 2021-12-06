using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day05 : Day
    {
        string[] instructions;
        List<List<(int x, int y)>> Lines;
        List<List<(int x, int y)>> NaughtyLines;
        int Max;
        int[,] TheGrid;
        int PartOne;
        public Day05(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List<int> finddMax = this.parseListOfInteger(Input);
            Max = finddMax.Max() + 1;
            PartOne = 0;
            TheGrid = new int[Max, Max];
            Lines = new List<List<(int x, int y)>>();
            NaughtyLines = new List<List<(int x, int y)>>();
            instructions = this.parseStringArray(Input);
            foreach (string s in instructions)
            {
                List<int> Row = this.parseListOfInteger(s);
                List<(int x, int y)> Line = new List<(int x, int y)>();
                if (Row[0] == Row[2])
                {
                    if (Row[1] < Row[3])
                    {
                        Line.Add((Row[0], Row[1]));
                        Line.Add((Row[2], Row[3]));
                    }
                    else
                    {
                        Line.Add((Row[2], Row[3]));
                        Line.Add((Row[0], Row[1]));
                    }
                    for (int i = Line[0].y + 1; i < Line[1].y; i++)
                        Line.Add((Line[0].x, i));

                    Lines.Add(Line);
                }
                else if (Row[1] == Row[3])
                {
                    if (Row[0] < Row[2])
                    {
                        Line.Add((Row[0], Row[1]));
                        Line.Add((Row[2], Row[3]));
                    }
                    else
                    {
                        Line.Add((Row[2], Row[3]));
                        Line.Add((Row[0], Row[1]));
                    }
                    for (int i = Line[0].x + 1; i < Line[1].x; i++)
                        Line.Add((i, Line[0].y));

                    Lines.Add(Line);
                }
                else
                {
                    if (Row[0] < Row[2])
                    {
                        Line.Add((Row[0], Row[1]));
                        Line.Add((Row[2], Row[3]));
                    }
                    else
                    {
                        Line.Add((Row[2], Row[3]));
                        Line.Add((Row[0], Row[1]));
                    }
                    int InvertMaybe = 1;
                    if (Line[0].y > Line[1].y)
                        InvertMaybe = -1;
                    for (int i = 1; i < (Line[1].x - Line[0].x); i++)
                        Line.Add((Line[0].x + i, Line[0].y + i * InvertMaybe));

                    NaughtyLines.Add(Line);
                }
            }
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            foreach (List<(int x, int y)> Line in Lines)
            {
                foreach ((int x, int y) c in Line)
                {
                    TheGrid[c.x, c.y]++;
                    if (TheGrid[c.x, c.y] == 2)
                        ReturnValue++;
                }
            }
            PartOne = ReturnValue;
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = PartOne;
            foreach (List<(int x, int y)> Line in NaughtyLines)
            {
                foreach ((int x, int y) c in Line)
                {
                    TheGrid[c.x, c.y]++;
                    if (TheGrid[c.x, c.y] == 2)
                        ReturnValue++;
                }
            }

            return ReturnValue.ToString();
        }
    }
}
