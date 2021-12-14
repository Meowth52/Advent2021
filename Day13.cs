using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day13 : Day
    {
        List<(char Axis, int Amount)> Instructions;
        Dictionary<Coordinate, int> TheGrid;
        int MaxX;
        int MaxY;
        public Day13(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] Splitted = this.ParseStringArray(Input);
            TheGrid = new Dictionary<Coordinate, int>();
            Instructions = new List<(char Axis, int Amount)>();
            MaxX = 0;
            MaxY = 0;
            foreach (string s in Splitted)
            {
                List<int> Ints = this.ParseListOfInteger(s);
                if (Ints.Count == 2)
                {
                    TheGrid.Add(new Coordinate(Ints[0], Ints[1]), 0);
                    if (Ints[0] > MaxX)
                        MaxX = Ints[0];
                    if (Ints[1] > MaxY)
                        MaxY = Ints[1];
                }
                else
                {
                    Instructions.Add((s[11], Ints[0]));
                }
            }
            MaxX++;
            MaxY++;
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            this.Fold(Instructions[0].Axis, Instructions[0].Amount);
            ReturnValue = TheGrid.Count;
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            for (int i = 1; i < Instructions.Count; i++)
            {
                Fold(Instructions[i].Axis, Instructions[i].Amount);
            }
            return Print();
        }
        public void Fold(char axis, int amount)
        {
            Dictionary<Coordinate, int> NextGrid = new Dictionary<Coordinate, int>();
            foreach (KeyValuePair<Coordinate, int> k in TheGrid)
            {
                Coordinate NewCoordinate = k.Key;
                int Value = k.Value;
                if (axis == 'x' && k.Key.x > amount)
                {
                    NewCoordinate = new Coordinate(amount - (k.Key.x - amount), k.Key.y);
                    if (TheGrid.ContainsKey(NewCoordinate))
                        Value += TheGrid[NewCoordinate];
                }
                else if (axis == 'y' && k.Key.y > amount)
                {
                    NewCoordinate = new Coordinate(k.Key.x, amount - (k.Key.y - amount));
                    if (TheGrid.ContainsKey(NewCoordinate))
                        Value += TheGrid[NewCoordinate];
                }
                if (!NextGrid.ContainsKey(NewCoordinate))
                    NextGrid.Add(NewCoordinate, Value);
                else
                    NextGrid[NewCoordinate] = Math.Max(k.Value, Value);


            }
            TheGrid = new Dictionary<Coordinate, int>(NextGrid);
        }
        public string Print()
        {
            StringBuilder ReturnValue = new StringBuilder();
            bool[,] Canvas = new bool[MaxX, MaxY];
            foreach (KeyValuePair<Coordinate, int> k in TheGrid)
            {
                Canvas[k.Key.x, k.Key.y] = true;
            }
            for (int y = 0; y < MaxY; y++)
            {
                ReturnValue.Append("\r\n");
                for (int x = 0; x < MaxX; x++)
                {
                    if (Canvas[x, y])
                        ReturnValue.Append("x");
                    else
                        ReturnValue.Append(".");
                }
            }
            return ReturnValue.ToString();
        }
    }
}
