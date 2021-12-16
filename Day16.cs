using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace Advent2021
{
    public class Day16 : Day
    {
        List<bool> Instructions;
        int Index;
        List<Packet> AllThePackets;
        public Day16(string _input) : base(_input)
        {
            string Input = this.ParseJustOneLine(this.CheckFile(_input));
            Instructions = new List<bool>();
            for (int i = 0; i < Input.Length; i += 2)
            {
                List<byte> Bajts = new List<byte>();
                Bajts.Add(Byte.Parse(Input.Substring(i, 2), style: System.Globalization.NumberStyles.HexNumber));
                BitArray Bjat = new BitArray(Bajts.ToArray());
                for (int bi = 7; bi >= 0; bi--)
                {
                    Instructions.Add(Bjat[bi]);
                }
            }
            Index = 0;
            AllThePackets = new List<Packet>();
            while (Index < Instructions.Count)
            {
                AllThePackets.Add(new Packet(ref Instructions, ref Index));
                ;
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            ReturnValue = AllThePackets[0].GetVersionNumber();
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            long ReturnValue = 0;
            ReturnValue = AllThePackets[0].GetOperating();
            return ReturnValue.ToString();
        }
        public class Packet
        {
            public int Version;
            public int Type;
            List<long> Numbers;
            List<Packet> Packets;
            public Packet(ref List<bool> Instructions, ref int Index)
            {
                Version = (int)Packet.FromBooleans(Instructions.GetRange(Index, 3));
                Index += 3;
                Type = (int)Packet.FromBooleans(Instructions.GetRange(Index, 3));
                Index += 3;
                Numbers = new List<long>();
                Packets = new List<Packet>();


                if (this.Type == 4)
                {
                    List<bool> Number = new List<bool>();
                    bool More = true;
                    while (More)
                    {
                        More = Instructions[Index];
                        Index++;
                        Number.AddRange(Instructions.GetRange(Index, 4));
                        Index += 4;
                        ;
                    }
                    this.AddNumber(Number);
                    if (!Instructions.GetRange(Index, Instructions.Count - (Index)).Contains(true))
                        Index = Instructions.Count;
                }
                else
                {
                    if (Instructions[Index])
                    {
                        Index++;
                        int Lenght = (int)Packet.FromBooleans(Instructions.GetRange(Index, 11));
                        Index += 11;
                        for (int i = 0; i < Lenght; i++)
                            Packets.Add(new Packet(ref Instructions, ref Index));
                    }
                    else
                    {

                        Index++;
                        int Lenght = (int)Packet.FromBooleans(Instructions.GetRange(Index, 15));
                        Index += 15;
                        int SubLenght = Index + Lenght;
                        while (Index < SubLenght)
                        {
                            Packets.Add(new Packet(ref Instructions, ref Index));
                        }
                    }
                }

            }
            public int GetVersionNumber()
            {
                int ReturnValue = this.Version;
                foreach (Packet p in this.Packets)
                    ReturnValue += p.GetVersionNumber();
                return ReturnValue;
            }
            public long GetOperating()
            {
                long ReturnValue = 0;
                List<long> Values = new List<long>();
                foreach (Packet p in Packets)
                    Values.Add(p.GetOperating());
                switch (this.Type)
                {
                    case 0:
                        foreach (long i in Values)
                            ReturnValue += i;
                        break;
                    case 1:
                        ReturnValue = 1;
                        foreach (long i in Values)
                            ReturnValue *= i;
                        break;
                    case 2:
                        ReturnValue = Values.Min();
                        break;
                    case 3:
                        ReturnValue = Values.Max();
                        break;
                    case 4:
                        ReturnValue = Numbers[0];
                        break;
                    case 5:
                        ReturnValue = Values[0] > Values[1] ? 1 : 0;
                        break;
                    case 6:
                        ReturnValue = Values[0] < Values[1] ? 1 : 0;
                        break;
                    case 7:
                        ReturnValue = Values[0] == Values[1] ? 1 : 0;
                        break;
                    default:
                        break;
                }
                return ReturnValue;
            }
            public static long FromBooleans(List<bool> b)
            {
                long ReturnValue = 0;
                long DoubleIsNotEnough = 1;
                for (int i = b.Count - 1; i >= 0; i--)
                {
                    if (b[i])
                        ReturnValue += DoubleIsNotEnough;//(long)Math.Pow(2, b.Count - (i + 1));
                    DoubleIsNotEnough *= 2;
                }
                return ReturnValue;
            }
            public void AddNumber(List<bool> b)
            {
                Numbers.Add(FromBooleans(b));
            }

        }

    }
}
