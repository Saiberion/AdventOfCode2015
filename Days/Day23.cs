using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day23: Day
    {
        public Day23()
        {
            Part1Text = "value of register b";
            Part2Text = "value of register b (a = 1)";

            Load("inputs/day23.txt");
        }

        private int RunProgram(List<string[]> instructions, bool part2)
        {
            int offset;
            Dictionary<string, int> registers = new Dictionary<string, int>
            {
                { "a", 0 },
                { "b", 0 }
            };

            if (part2)
            {
                registers["a"] = 1;
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                switch (instructions[i][0])
                {
                    case "hlf":
                        registers[instructions[i][1]] /= 2;
                        break;
                    case "tpl":
                        registers[instructions[i][1]] *= 3;
                        break;
                    case "inc":
                        registers[instructions[i][1]]++;
                        break;
                    case "jmp":
                        offset = int.Parse(instructions[i][1]) - 1;
                        i += offset;
                        break;
                    case "jie":
                        if ((registers[instructions[i][1]] % 2) == 0)
                        {
                            offset = int.Parse(instructions[i][2]) - 1;
                            i += offset;
                        }
                        break;
                    case "jio":
                        if (registers[instructions[i][1]] == 1)
                        {
                            offset = int.Parse(instructions[i][2]) - 1;
                            i += offset;
                        }
                        break;
                }
            }

            return registers["b"];
        }

        override public void Solve()
        {
            List<string[]> instructions = new List<string[]>();

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                instructions.Add(splitted);
            }

            Part1Solution = RunProgram(instructions, false).ToString();
            Part2Solution = RunProgram(instructions, true).ToString();
        }
    }
}
