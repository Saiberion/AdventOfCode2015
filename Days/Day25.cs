using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day25: Day
    {
        public Day25()
        {
            Part1Text = "Found code";
            Part2Text = "Weather Machine";

            Load("inputs/day25.txt");
        }

        override public void Solve()
        {
            int row = 2981;
            int col = 3075;
            int r = 1, c = 1;
            int index = 1;
            int maxrow = 1;
            long code = 20151125;

            while(!((r == row) && (c == col)))
            {
                r--;
                c++;
                if (r == 0)
                {
                    c = 1;
                    r = ++maxrow;
                }
                index++;
                code *= 252533;
                code %= 33554393;
            }

            Part1Solution = code.ToString();
            Part2Solution = "Active";
        }
    }
}
