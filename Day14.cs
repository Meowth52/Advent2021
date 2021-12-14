using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2021
{
    public class Day14 : Day
    {
        Dictionary<string, List<string>> Instructions;
        char First;
        char Last;
        Dictionary<string, long> Elements;
        Dictionary<string, long> OtherElements;
        Dictionary<char, long> Score;
        public Day14(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] splitted = this.parseStringArray(Input);
            string startString = splitted[0];
            First = startString.First();
            Last = startString.Last();
            Elements = new Dictionary<string, long>();
            Instructions = new Dictionary<string, List<string>>();
            Score = new Dictionary<char, long>();
            for (int i = 0; i < startString.Length - 1; i++)
            {
                string Element = startString[i].ToString() + startString[i + 1].ToString();
                if (!Elements.ContainsKey(Element))
                    Elements.Add(Element, 0);
                Elements[Element]++;
                this.Scoreinate(startString[i], 1);
            }
            this.Scoreinate(startString.Last(), 1);
            foreach (string s in splitted)
            {
                if (s != startString)
                {
                    string from = s.Substring(0, 2);
                    string to = s.Last().ToString();
                    Instructions.Add(from, new List<string>()
                    {
                        {from.Substring(0,1) + to },
                        {to+ from.Substring(1,1) }
                    });
                }
            }
        }
        public override Tuple<string, string> getResult()
        {
            return getPartOne();
        }
        public Tuple<string, string> getPartOne()
        {
            long ReturnValue = 0;
            long ReturnValue2 = 0;
            for (int i = 0; i < 40; i++)
            {
                OtherElements = new Dictionary<string, long>(Elements);
                foreach (KeyValuePair<string, List<string>> k in Instructions)
                    Instruct(k.Key, k.Value);
                Elements = new Dictionary<string, long>(OtherElements);
                if (i == 9)
                    ReturnValue = ScoreCount();
            }
            ReturnValue2 = ScoreCount();
            return Tuple.Create(ReturnValue.ToString(), ReturnValue2.ToString());
        }
        public string getPartTwo() //nope
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public void Instruct(string key, List<string> results)
        {
            if (Elements.ContainsKey(key) && Elements[key] > 0)
            {
                this.Scoreinate(results[0][1], Elements[key]);
                foreach (string s in results)
                {
                    if (!OtherElements.ContainsKey(s))
                        OtherElements.Add(s, 0);
                    OtherElements[s] += Elements[key];
                }
                OtherElements[key] -= Elements[key];
            }
        }
        public void Scoreinate(char c, long i)
        {
            if (!Score.ContainsKey(c))
                Score.Add(c, 0);
            Score[c] += i;
        }
        public long ScoreCount()
        {
            long Most = 0;
            long Least = 10000000000000;
            foreach (KeyValuePair<char, long> s in Score)
            {
                if (s.Value > Most)
                    Most = s.Value;
                if (s.Value < Least)
                    Least = s.Value;
            }
            return Most - Least;
        }
    }
}
