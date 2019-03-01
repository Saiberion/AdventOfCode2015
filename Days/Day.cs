using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    abstract public class Day
    {
        public string Part1Text { get; internal set; }
        public string Part1Solution { get; set; }
        public string Part2Text { get; internal set; }
        public string Part2Solution { get; set; }
        abstract public void Solve(List<string> input);
    }
}
