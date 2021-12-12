using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day11 : Day
    {
        Dictionary<Coordinate, int> Octopussy;
        List<Coordinate> OctoKeys;
        int ReturnValue2;
        public Day11(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] rows = this.parseStringArray(Input);
            Octopussy = new Dictionary<Coordinate, int>(); ;
            for (int y = 0; y < rows.Length; y++)
                for (int x = 0; x < rows[0].Length; x++)
                    Octopussy.Add(new Coordinate(x, y), Int32.Parse(rows[y][x].ToString()));
            OctoKeys = new List<Coordinate>();
            foreach (KeyValuePair<Coordinate, int> c in Octopussy)
                OctoKeys.Add(c.Key);
            ReturnValue2 = 0;
        }
        public override Tuple<string, string> getResult()
        {
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            int TotalFlashes = 0;
            List<Coordinate> Flashes = new List<Coordinate>();
            List<Coordinate> Flashed = new List<Coordinate>();
            int i = 0;
            while (true)
            {
                foreach (Coordinate c in OctoKeys)
                {
                    Octopussy[c]++;
                    if (Octopussy[c] > 9)
                    {
                        Flashes.Add(c);
                    }
                }
                Flashed = new List<Coordinate>(Flashes);
                while (Flashes.Count > 0)
                {
                    List<Coordinate> NextFlashes = new List<Coordinate>();
                    foreach (Coordinate c in Flashes)
                    {
                        foreach (Coordinate n in c.GetNeihbours(Diagonals: true))
                        {
                            if (Octopussy.ContainsKey(n))
                            {
                                Octopussy[n]++;
                                if (Octopussy[n] > 9 && !Flashed.Contains(n))
                                {
                                    NextFlashes.Add(n);
                                    Flashed.Add(n);
                                }
                            }
                        }
                    }
                    Flashes = new List<Coordinate>(NextFlashes);
                }
                foreach (Coordinate c in OctoKeys)
                    if (Octopussy[c] > 9)
                    {
                        Octopussy[c] = 0;
                        TotalFlashes++;
                    }
                if (i == 99)
                {
                    ReturnValue = TotalFlashes;
                }
                i++;
                if (Flashed.Count == 100)
                {
                    ReturnValue2 = i;
                    break;
                }
            }
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = ReturnValue2;

            return ReturnValue.ToString();
        }
    }
}
