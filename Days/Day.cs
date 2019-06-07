using System;
using System.Collections.Generic;
using System.IO;
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
        public string Name { get; set; }
        internal List<string> Input { get; set; }
        public System.Diagnostics.Stopwatch StopWatch { get; set; }

        abstract public void Solve();

        internal void Load(string filename)
        {
            StreamReader file = new StreamReader(filename);
            Input = new List<string>();
            string line;

            while ((line = file.ReadLine()) != null)
            {
                Input.Add(line);
            }

            file.Close();
        }
    }
}
