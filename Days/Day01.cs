using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    public class Day01 : Day
    {
        public Day01()
        {
            Part1Text = "Santa is at floor";
            Part2Text = "Entered basement at step";

            Load("inputs/day01.txt");
        }

        override public void Solve()
        {
            int floor = 0;
            int stepsTaken = 0;
            bool enteredBasement = false;
            foreach(string s in Input)
            {
                foreach(char c in s)
                {
                    if (c == '(')
                    {
                        floor++;
                    }
                    else if (c == ')')
                    {
                        floor--;
                    }
                    stepsTaken++;
                    if (floor < 0)
                    {
                        if (!enteredBasement)
                        {
                            enteredBasement = true;
                            Part2Solution = stepsTaken.ToString();
                        }
                    }
                }
            }

            Part1Solution = floor.ToString();
        }
    }
}
