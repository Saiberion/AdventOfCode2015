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
            Day d = new Day04();
            d.Solve();
            Console.WriteLine("{0}: {1}", d.Part1Text, d.Part1Solution);
            Console.WriteLine("{0}: {1}", d.Part2Text, d.Part2Solution);
            Console.ReadLine();
        }
    }
}
