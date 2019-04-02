using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day10 : Day
    {
        public Day10()
        {
            Part1Text = "Look-And-Say length after 40 iterations";
            Part2Text = "Look-And-Say length after 50 iterations";

            Load("inputs/day10.txt");
        }

        string LookAndSay(string origin, int iterations)
        {
            StringBuilder sb = new StringBuilder();
            for (int iter = 0; iter < iterations; iter++)
            {
                for (int i = 0; i < origin.Length; i++)
                {
                    int j;
                    char see = origin[i];
                    int count = 1;
                    for (j = i + 1; j < origin.Length; j++)
                    {
                        if (see == origin[j])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    i = j - 1;
                    sb.Append(count);
                    sb.Append(see);
                }
                origin = sb.ToString();
                sb.Clear();
            }
            return origin;
        }

        override public void Solve()
        {
            string origin = Input[0];

            origin = LookAndSay(origin, 40).ToString();
            Part1Solution = origin.Length.ToString();
            origin = LookAndSay(origin, 10).ToString();
            Part2Solution = origin.Length.ToString();
        }
    }
}
