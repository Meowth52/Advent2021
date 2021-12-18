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
        int OwDamned;
        public Day17(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List<int> Instructions = this.ParseListOfInteger(Input);
            XLimits = (Instructions[0], Instructions[1]);
            YLimits = (Instructions[2], Instructions[3]);
            OwDamned = 0;
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
                    if (HitOnX(XLimits) > 0)
                    {
                        break;
                    }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            int CeheckValue = 0;
            for (int y = 10000; y > (YLimits.Min - 1); y--)
            {
                CeheckValue = HitOnY(YLimits, y);
                if (CeheckValue != 0)
                {
                    int well = HitOnX(XLimits);
                    if (well > 0)
                    {
                        ReturnValue += well;
                    }
                }
            }
            return ReturnValue.ToString();
        }
        public int HitOnX((int Min, int Max) Limits)
        {
            int Hit = 0;
            for (int i = 1; i <= Limits.Max; i++)
            {
                int xv = i;
                int x = 0;
                for (int xi = 0; xi <= OwDamned; xi++)
                {
                    if (xi == OwDamned && x >= Limits.Min && x <= Limits.Max)
                    {
                        Hit++;
                    }
                    x += xv;
                    if (xv > 0)
                        xv--;
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
            OwDamned = 0;
            while (y >= Limits.Min)
            {
                OwDamned++;
                if (y <= Limits.Max)
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
