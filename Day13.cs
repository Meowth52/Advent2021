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
        public Day13(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] Splitted = this.parseStringArray(Input);
            TheGrid = new Dictionary<Coordinate, int>();
            Instructions = new List<(char Axis, int Amount)>();
            foreach (string s in Splitted)
            {
                List<int> Ints = this.parseListOfInteger(s);
                if (Ints.Count == 2)
                    TheGrid.Add(new Coordinate(Ints[0], Ints[1]), 0);
                else
                {
                    Instructions.Add((s[11], Ints[0]));
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
            this.Fold(Instructions[0].Axis, Instructions[0].Amount);
            ReturnValue = TheGrid.Count;
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
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
                    NewCoordinate = new Coordinate(k.Key.x - (amount + 1), k.Key.y);
                    if (TheGrid.ContainsKey(NewCoordinate))
                        Value++;
                }
                else if (k.Key.y > amount)
                {
                    NewCoordinate = new Coordinate(k.Key.x, k.Key.y - (amount + 1));
                    if (TheGrid.ContainsKey(NewCoordinate))
                        Value++;
                }
                if (!NextGrid.ContainsKey(NewCoordinate))
                    NextGrid.Add(NewCoordinate, Value);
                else
                    NextGrid[NewCoordinate] = Math.Max(k.Value, Value);


            }
            TheGrid = new Dictionary<Coordinate, int>(NextGrid);
        }
    }
}
