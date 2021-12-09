using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day09 : Day
    {
        Dictionary<Coordinate, int> TheGrid;
        List<Coordinate> Lowpoints;
        public Day09(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] strings = this.parseStringArray(Input);
            TheGrid = new Dictionary<Coordinate, int>();
            for (int x = 0; x < strings[0].Length; x++)
            {
                for (int y = 0; y < strings.Length; y++)
                {
                    TheGrid.Add(new Coordinate(x, y), Int32.Parse(strings[y][x].ToString()));
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
            Lowpoints = new List<Coordinate>();
            foreach (KeyValuePair<Coordinate, int> coo in TheGrid)
            {
                List<Coordinate> Neihbours = coo.Key.GetNeihbours();
                bool LowPoint = true;
                foreach (Coordinate n in Neihbours)
                {
                    if (TheGrid.ContainsKey(n))
                        if (TheGrid[n] <= coo.Value)
                            LowPoint = false;
                }
                if (LowPoint)
                {
                    ReturnValue += 1 + coo.Value;
                    Lowpoints.Add(coo.Key);
                }
            }
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 1;
            List<Coordinate> Avoid = new List<Coordinate>();
            List<int> Areas = new List<int>();
            foreach (Coordinate coo in Lowpoints)
            {
                if (!Avoid.Contains(coo))
                {
                    List<Coordinate> Area = new List<Coordinate>();
                    Area.Add(coo);
                    List<Coordinate> Edge = new List<Coordinate>();
                    Edge.Add(coo);
                    while (Edge.Count > 0)
                    {
                        List<Coordinate> NextEdge = new List<Coordinate>();
                        foreach (Coordinate e in Edge)
                        {
                            List<Coordinate> Neighbours = e.GetNeihbours();
                            foreach (Coordinate n in Neighbours)
                            {
                                if (TheGrid.ContainsKey(n) && !Area.Contains(n) && TheGrid[n] != 9)
                                {
                                    if (Lowpoints.Contains(n))
                                    {
                                        Avoid.Add(n);
                                    }
                                    Area.Add(n);
                                    NextEdge.Add(n);
                                }
                            }
                        }
                        Edge = new List<Coordinate>(NextEdge);
                    }
                    Areas.Add(Area.Count);
                }
            }
            Areas = Areas.OrderByDescending(x => x).ToList();
            for (int i = 0; i < 3; i++)
            {
                ReturnValue *= Areas[i];
            }
            return ReturnValue.ToString();
        }
    }
}
