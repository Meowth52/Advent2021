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
        public Day17(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List<int> Instructions = this.ParseListOfInteger(Input);
            XLimits = (Instructions[0], Instructions[1]);
            YLimits = (Instructions[2], Instructions[3]);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            for (int y = 100000; y > 0; y--)
            {
                ReturnValue = HitOnY(YLimits, y);
                if (ReturnValue > 0)
                    if (HitOnX(XLimits, y))
                    {
                        break;
                    }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public bool HitOnX((int Max, int Min) Limits, int y)
        {
            bool Hit = false;
            for (int i = 1; i <= Limits.Max; i++)
            {
                int xv = i;
                int x = 0;
                Hit = false;
                for (int xi = 0; xi <= y; xi++)
                {
                    x += xv;
                    if (xv > 0)
                        xv--;
                    else
                        break;
                    if (xi == y && x >= Limits.Min)
                    {
                        Hit = true;
                        break;
                    }
                }
                if (Hit)
                    break;
            }
            return Hit;
        }
        public int HitOnY((int Max, int Min) Limits, int Velocity)
        {
            int ReturnValue = 0;
            int yv = Velocity;
            bool Hit = false;
            int y = 0;
            while (y >= Limits.Max)
            {
                if (y <= Limits.Min)
                {
                    Hit = true;
                    break;
                }
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
