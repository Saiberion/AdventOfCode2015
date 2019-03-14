using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    public class Day05: Day
    {
        public Day05()
        {
            Part1Text = "Nice Strings";
            Part2Text = "Nice Strings new rules";

            Load("inputs/day05.txt");
        }

        private bool HasEnoughVowels(string s)
        {
            int vowelCount = 0;
            foreach(char c in s)
            {
                if ((c == 'a') || (c == 'e') || (c == 'i') || (c == 'o') || (c == 'u'))
                {
                    vowelCount++;
                }
            }
            return vowelCount >= 3;
        }

        private bool HasDoubleLetter(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasNoBannedStrings(string s)
        {
            if (s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"))
            {
                return false;
            }
            return true;
        }

        private bool HasMultipleDoubles(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                string compare = string.Format("{0}{1}", s[i], s[i + 1]);
                if (s.Remove(0, i + 2).Contains(compare))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasPatternABA(string s)
        {
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] == s[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

        override public void Solve()
        {
            int niceStrings = 0;
            foreach (string s in Input)
            {
                if (HasEnoughVowels(s) && HasDoubleLetter(s) && HasNoBannedStrings(s))
                {
                    niceStrings++;
                }
            }
            Part1Solution = niceStrings.ToString();

            niceStrings = 0;
            foreach (string s in Input)
            {
                if (HasMultipleDoubles(s) && HasPatternABA(s))
                {
                    niceStrings++;
                }
            }
            Part2Solution = niceStrings.ToString();
        }
    }
}
