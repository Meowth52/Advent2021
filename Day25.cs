using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day25 : Day
    {
        char[,] TheGrid;
        int MaxX;
        int MaxY;
        public Day25(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] instructions = this.ParseStringArray(Input);
            MaxX = instructions[0].Length - 1;
            MaxY = instructions.Length - 1;
            TheGrid = new char[MaxX + 1, MaxY + 1];
            for (int y = 0; y <= MaxY; y++)
            {
                for (int x = 0; x <= MaxX; x++)
                {
                    TheGrid[x, y] = instructions[y][x];
                }
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            bool Moved = true;
            while (Moved)
            {
                ReturnValue++;
                Moved = false;
                Dictionary<Coordinate, char> NextGrid = new Dictionary<Coordinate, char>();
                for (int y = 0; y <= MaxY; y++)
                {
                    char last = TheGrid[MaxX, y];
                    for (int x = 0; x <= MaxX; x++)
                    {
                        if (last == '>' && TheGrid[x, y] == '.')
                        {
                            NextGrid.Add(new Coordinate(x, y), '>');
                            int LastX = x - 1;
                            if (LastX < 0)
                                LastX = MaxX;
                            NextGrid.Add(new Coordinate(LastX, y), '.');
                            Moved = true;
                        }
                        last = TheGrid[x, y];
                    }
                }
                foreach (KeyValuePair<Coordinate, char> c in NextGrid)
                    TheGrid[c.Key.x, c.Key.y] = c.Value;
                NextGrid.Clear();
                for (int x = 0; x <= MaxX; x++)
                {
                    char last = TheGrid[x, MaxY];
                    for (int y = 0; y <= MaxY; y++)
                    {
                        if (last == 'v' && TheGrid[x, y] == '.')
                        {
                            NextGrid.Add(new Coordinate(x, y), 'v');
                            int LastY = y - 1;
                            if (LastY < 0)
                                LastY = MaxY;
                            Coordinate c = new Coordinate(x, LastY);
                            if (!NextGrid.ContainsKey(c))
                                NextGrid.Add(c, '.');
                            else
                                NextGrid[c] = '.';
                            Moved = true;
                        }
                        last = TheGrid[x, y];
                    }
                }
                foreach (KeyValuePair<Coordinate, char> c in NextGrid)
                    TheGrid[c.Key.x, c.Key.y] = c.Value;
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
    }
}
