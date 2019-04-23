using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day17: Day
    {
        public static List<List<int>> combinations;

        public Day17()
        {
            Part1Text = "number of combinations";
            Part2Text = "Combinations with lowest container amount";

            Load("inputs/day17.txt");

            combinations = new List<List<int>>();
        }

        private static void SumUpRecursive(List<int> numbers, int target, List<int> partial)
        {
            int s = 0;
            foreach (int x in partial) s += x;

            if (s == target)
            {
                combinations.Add(new List<int>(partial));
            }

            if (s >= target)
            {
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }

                List<int> partial_rec = new List<int>(partial)
                {
                    n
                };
                SumUpRecursive(remaining, target, partial_rec);
            }
        }

        private static void SumUp(List<int> numbers, int target)
        {
            SumUpRecursive(numbers, target, new List<int>());
        }

        override public void Solve()
        {
            int target = 150;
            List<int> bottles = new List<int>();
            foreach (string s in Input)
            {
                bottles.Add(int.Parse(s));
            }

            SumUp(bottles, target);
            Part1Solution = combinations.Count.ToString();

            int minContainer = int.MaxValue;
            foreach(List<int> l in combinations)
            {
                minContainer = Math.Min(minContainer, l.Count);
            }

            for (int i = 0; i < combinations.Count; i++)
            {
                if (combinations[i].Count != minContainer)
                {
                    combinations.RemoveAt(i);
                    i--;
                    continue;
                }
            }

            Part2Solution = combinations.Count.ToString();
        }
    }
}
