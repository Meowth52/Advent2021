using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RoyT.AStar;

namespace Advent2021
{
    public class Day15 : Day
    {
        Grid TheGrid;
        int[,] thegrid;
        List<List<int>> TheSchmid;
        int MaxX;
        int MaxY;
        public Day15(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] splitted = this.ParseStringArray(Input);
            thegrid = new int[splitted[0].Length, splitted.Length];
            MaxX = splitted.Length;
            MaxY = splitted[0].Length;
            TheGrid = new Grid(MaxX, MaxY, 1);
            TheSchmid = new List<List<int>>();
            for (int y = 0; y < MaxY; y++)
            {
                TheSchmid.Add(new List<int>());
                for (int x = 0; x < MaxX; x++)
                {
                    int i = Int32.Parse(splitted[y][x].ToString());
                    thegrid[x, y] = i;
                    TheGrid.SetCellCost(new Position(x, y), i);
                    TheSchmid.Last().Add(i);
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
            Position[] path = TheGrid.GetPath(new Position(0, 0), new Position(MaxX - 1, MaxY - 1), MovementPatterns.LateralOnly);
            foreach (Position p in path)
            {
                ReturnValue += thegrid[p.X, p.Y];
            }
            ReturnValue -= thegrid[0, 0];
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            int[,] ThEgRiD = new int[MaxX * 5, MaxY * 5];
            Grid THEGRID = new Grid(MaxX * 5, MaxY * 5, 1);
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int yy = 0; yy < MaxY; yy++)
                    {
                        for (int xx = 0; xx < MaxX; xx++)
                        {
                            int i = thegrid[xx, yy] + x + y;
                            if (i > 9)
                                i -= 9;
                            ThEgRiD[x * MaxX + xx, y * MaxY + yy] = i;
                            THEGRID.SetCellCost(new Position(x * MaxX + xx, y * MaxY + yy), i);
                        }
                    }

                }
            }
            Position[] path = THEGRID.GetPath(new Position(0, 0), new Position(MaxX * 5 - 1, MaxY * 5 - 1), MovementPatterns.LateralOnly);
            foreach (Position p in path)
            {
                ReturnValue += ThEgRiD[p.X, p.Y];
            }
            ReturnValue -= ThEgRiD[0, 0];
            return ReturnValue.ToString();
        }
    }
}
