using Days;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("inputs/day01.txt");
            List<string> input = new List<string>();
            string line;

            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }

            file.Close();

            Day d = new Day01();
            d.Solve(input);
            Console.WriteLine("{0}: {1}", d.Part1Text, d.Part1Solution);
            Console.WriteLine("{0}: {1}", d.Part2Text, d.Part2Solution);
            Console.ReadLine();
        }
    }
}
