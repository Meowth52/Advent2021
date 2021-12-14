using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day08 : Day
    {
        string[] Instructions;
        List<(string[] Key, string[] Value)> Strings;
        public Day08(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            Strings = new List<(string[] Key, string[] Value)>();
            foreach (string s in Instructions)
            {
                string[] splitted = s.Split('|');
                Strings.Add(
                    (splitted[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                    splitted[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));

            }
            foreach ((string[] Key, string[] Value) s in Strings)
            {
                foreach (string ss in s.Value)
                {
                    if (ss.Length == 2 || ss.Length == 3 || ss.Length == 4 || ss.Length == 7)
                        ReturnValue++;
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            foreach ((string[] Key, string[] Value) s in Strings)
            {
                Dictionary<char, char> Configurations = new Dictionary<char, char>();
                Dictionary<char, int> Frequency = new Dictionary<char, int>()
                {
                    {'a',0 },
                    {'b',0 },
                    {'c',0 },
                    {'d',0 },
                    {'e',0 },
                    {'f',0 },
                    {'g',0 }
                };
                Dictionary<int, string> Numbers = new Dictionary<int, string>();
                foreach (string ss in s.Key)
                {
                    foreach (char c in ss)
                        Frequency[c]++;
                    switch (ss.Length)
                    {
                        case 2:
                            Numbers.Add(1, String.Concat(ss.OrderBy(c => c)));
                            break;
                        case 3:
                            Numbers.Add(7, String.Concat(ss.OrderBy(c => c)));
                            break;
                        case 4:
                            Numbers.Add(4, String.Concat(ss.OrderBy(c => c)));
                            break;
                        case 7:
                            Numbers.Add(8, String.Concat(ss.OrderBy(c => c)));
                            break;
                        default:
                            break;
                    }
                }
                char b = Frequency.Where(x => x.Value == 6).First().Key;
                Configurations.Add('b', b);
                char e = Frequency.Where(x => x.Value == 4).First().Key;
                Configurations.Add('e', e);
                char f = Frequency.Where(x => x.Value == 9).First().Key;
                Configurations.Add('f', f);
                IEnumerable<KeyValuePair<char, int>> ac = Frequency.Where(x => x.Value == 8).ToList();
                foreach (KeyValuePair<char, int> pair in ac)
                    if (!Numbers[1].Contains(pair.Key))
                        Configurations.Add('a', pair.Key);
                    else
                        Configurations.Add('c', pair.Key);
                IEnumerable<KeyValuePair<char, int>> dg = Frequency.Where(x => x.Value == 7);
                foreach (KeyValuePair<char, int> pair in dg)
                    if (!Numbers[4].Contains(pair.Key))
                        Configurations.Add('g', pair.Key);
                    else
                        Configurations.Add('d', pair.Key);
                string Number = "";
                List<string> Debug = new List<string>();
                foreach (string ss in s.Value)
                {
                    string Temp = "";
                    foreach (char cc in ss)
                        Temp += Configurations.Where(x => x.Value == cc).First().Key;
                    string Sorted = String.Concat(Temp.OrderBy(x => x));
                    Debug.Add(Sorted);
                    switch (Sorted)
                    {
                        case "abcefg":
                            Number += "0";
                            break;
                        case "cf":
                            Number += "1";
                            break;
                        case "acdeg":
                            Number += "2";
                            break;
                        case "acdfg":
                            Number += "3";
                            break;
                        case "bcdf":
                            Number += "4";
                            break;
                        case "abdfg":
                            Number += "5";
                            break;
                        case "abdefg":
                            Number += "6";
                            break;
                        case "acf":
                            Number += "7";
                            break;
                        case "abcdefg":
                            Number += "8";
                            break;
                        case "abcdfg":
                            Number += "9";
                            break;
                        default:
                            break;
                    }
                    ;

                }
                ReturnValue += Int32.Parse(Number);

            }

            return ReturnValue.ToString();
        }
    }
}
