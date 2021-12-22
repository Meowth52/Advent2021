using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day22 : Day
    {
        bool[,,] IntitiationMatrix;
        string[] Instructions;
        public Day22(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
            IntitiationMatrix = new bool[101, 101, 101];
            List<int> AllTheNumbers = this.ParseListOfInteger(Input);
            int Min = AllTheNumbers.Min();
            int Max = AllTheNumbers.Max();
            foreach (string s in Instructions)
            {
                bool on = false;
                if (s[1] == 'n')
                    on = true;
                List<int> Numbers = this.ParseListOfInteger(s);
                for (int x = Math.Max(Numbers[0], -50); x <= Math.Min(Numbers[1], 50); x++)
                {
                    for (int y = Math.Max(Numbers[2], -50); y <= Math.Min(Numbers[3], 50); y++)
                    {
                        for (int z = Math.Max(Numbers[4], -50); z <= Math.Min(Numbers[5], 50); z++)
                        {
                            IntitiationMatrix[x + 50, y + 50, z + 50] = on;
                        }
                    }
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
            foreach (bool b in IntitiationMatrix)
                if (b)
                    ReturnValue++;
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public class Cube
        {
            long MinX;
            long MaxX;
            long MinY;
            long MaxY;
            long MinZ;
            long MaxZ;
            public Cube(long minx, long maxX, long minY, long maxY, long minZ, long maxZ)
            {
                MinX = minx;
                MaxX = maxX;
                MinY = minY;
                MaxY = maxY;
                MinZ = minZ;
                MaxZ = maxZ;
            }
            public List<Cube> SplitOnSpot(long x, long y, long z)
            {
                List<Cube> ReturnCubes = new List<Cube>();
                ReturnCubes.Add(new Cube(MinX, x, MinY, y, MinZ, z));
                ReturnCubes.Add(new Cube(x, MaxX, MinY, y, MinZ, z));
                ReturnCubes.Add(new Cube(MinX, x, y, MaxY, MinZ, z));
                ReturnCubes.Add(new Cube(MinX, x, MinY, y, z, MaxZ));
                ReturnCubes.Add(new Cube(x, MaxX, y, MaxY, MinZ, z));
                ReturnCubes.Add(new Cube(MinX, x, y, MaxY, z, MaxZ));
                ReturnCubes.Add(new Cube(x, MaxX, MinY, y, z, MaxZ));
                ReturnCubes.Add(new Cube(x, MaxX, y, MaxY, z, MaxZ));
                return ReturnCubes;
            }
            //public List<(int x, int y,int z)> IsOverlap(Cube OtherCube)
            //{

            //}
            //public int FindOverlap(Cube OtherCube)
            //{
            //    int X = OtherCube
            //}
        }
    }
}
