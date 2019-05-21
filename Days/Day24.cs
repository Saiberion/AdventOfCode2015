using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day24: Day
    {
        public Day24()
        {
            Part1Text = "Min QE (3 stacks)";
            Part2Text = "Min QE (4 stacks)";

            Load("inputs/day24.txt");
        }

        private static Tuple<long, int> Balance(List<int> weights, int pos, int remWt, long currQe, int currCt)
        {
            if (remWt == 0)
            {
                return new Tuple<long, int>(currQe, currCt);
            }
            else if (remWt < 0 || pos == weights.Count)
            {
                return new Tuple<long, int>(long.MaxValue, int.MaxValue);
            }

            var included = Balance(weights, pos + 1, remWt - weights[pos], currQe * weights[pos], currCt + 1);
            var notIncluded = Balance(weights, pos + 1, remWt, currQe, currCt);

            if (included.Item2 < notIncluded.Item2)
            {
                return included;
            }
            else if (notIncluded.Item2 < included.Item2)
            {
                return notIncluded;
            }
            else
            {
                return (included.Item1 < notIncluded.Item1) ? included : notIncluded;
            }
        }

        override public void Solve()
        {
            List<int> weights = new List<int>();
            int totalWeight = 0;
            long minQE;

            foreach (string s in Input)
            {
                int i = int.Parse(s);
                weights.Add(i);
                totalWeight += i;
            }

            minQE = Balance(weights, 0, totalWeight / 3, 1, 0).Item1;
            Part1Solution = minQE.ToString();
            minQE = Balance(weights, 0, totalWeight / 4, 1, 0).Item1;
            Part2Solution = minQE.ToString();
        }
    }
}
