using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day20: Day
    {
        public Day20()
        {
            Part1Text = "First house with given presents (10 per elf)";
            Part2Text = "First house with given presents (11 per elf)";

            Load("inputs/day20.txt");
        }

        override public void Solve()
        {
            int thresholdPresents = int.Parse(Input[0]);

            int[] houses = new int[thresholdPresents / 10];

            int min = int.MaxValue;
            for (int i = 1; i < houses.Length; i++)
            {
                for (int j = i; j < houses.Length; j += i)
                {
                    houses[j] += i * 10;
                    if (houses[j] >= thresholdPresents)
                    {
                        min = Math.Min(min, j);
                    }
                }
            }
            Part1Solution = min.ToString();

            int[] houses2 = new int[thresholdPresents * 2];
            for (int i = 1; i < houses2.Length; i++)
            {
                for (int x = 0; x < i * 50; x += i)
                {
                    houses2[x] += i * 11;
                    if (houses2[i] >= thresholdPresents)
                    {
                        Part2Solution = i.ToString();
                        return;
                    }
                }
            }
        }
    }
}
