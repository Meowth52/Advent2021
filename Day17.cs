using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day17 : Day
    {
        (int Min, int Max) XLimits;
        (int Min, int Max) YLimits;
        List<(int i, int y)> OwDamned;
        HashSet<(int x, int y)> Hits;
        public Day17(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List<int> Instructions = this.ParseListOfInteger(Input);
            XLimits = (Instructions[0], Instructions[1]);
            YLimits = (Instructions[2], Instructions[3]);
            OwDamned = new List<(int i, int y)>();
            Hits = new HashSet<(int x, int y)>();
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            for (int y = 10000; y > 0; y--)
            {
                ReturnValue = HitOnY(YLimits, y);
                if (ReturnValue > 0)
                    if (HitOnX(XLimits, y) > 0)
                    {
                        break;
                    }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            int CheckValue = 0;
            for (int y = 10000; y > (YLimits.Min - 1); y--)
            {
                CheckValue = HitOnY(YLimits, y);
                if (CheckValue != 0)
                {
                    int NumberOfHits = HitOnX(XLimits, y);
                    {
                        ;
                    }
                }
            }
            ReturnValue = Hits.Count;
            return ReturnValue.ToString();
        }
        public int HitOnX((int Min, int Max) Limits, int y)
        {
            int Hit = 0;
            foreach ((int i, int y) Ow in OwDamned)
            {
                for (int i = 0; i <= Limits.Max; i++)
                {
                    int xv = i;
                    int x = 0;
                    for (int xi = 0; xi <= Ow.i; xi++)
                    {
                        if (xi == Ow.i && x >= Limits.Min && x <= Limits.Max)
                        {
                            Hit++;
                            Hits.Add((i, y));
                        }
                        x += xv;
                        if (xv > 0)
                            xv--;
                    }
                }
            }
            return Hit;
        }
        public int HitOnY((int Min, int Max) Limits, int Velocity)
        {
            int ReturnValue = 1;
            int yv = Velocity;
            bool Hit = false;
            int y = 0;
            OwDamned = new List<(int i, int y)>();
            int Ow = 0;
            while (y >= Limits.Min)
            {
                if (y <= Limits.Max)
                {
                    Hit = true;
                    OwDamned.Add((Ow, y));
                }
                Ow++;
                y += yv;
                yv--;
                if (y >= ReturnValue)
                    ReturnValue = y;
            }
            if (!Hit)
                ReturnValue = 0;
            return ReturnValue;
        }
    }
}
