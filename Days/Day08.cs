using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day08: Day
    {
        public Day08()
        {
            Part1Text = "Original - decoded length";
            Part2Text = "Encoded - original length";

            Load("inputs/day08.txt");
        }

        override public void Solve()
        {
            int lengthInput = 0;
            int lengthDecoded = 0;
            StringBuilder sb = new StringBuilder();
            foreach (string s in Input)
            {
                lengthInput += s.Length;

                string str = s.Remove(s.Length - 1, 1).Remove(0, 1);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\\')
                    {
                        if ((str[i + 1] == '\\') || (str[i + 1] == '\"'))
                        {
                            str = str.Remove(i, 1);
                        }
                        else if (str[i + 1] == 'x')
                        {
                            str = str.Remove(i, 3);
                        }
                    }
                }
                lengthDecoded += str.Length;

                sb.Append("\"");
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] == '\\') || (s[i] == '\"'))
                    {
                        sb.Append("\\");
                    }
                    sb.Append(s[i]);
                }
                sb.Append("\"");
            }
            Part1Solution = (lengthInput - lengthDecoded).ToString();
            Part2Solution = (sb.Length - lengthInput).ToString();
        }
    }
}
