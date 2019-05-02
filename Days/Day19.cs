using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    class ReplacementRule
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class Day19: Day
    {
        public Day19()
        {
            Part1Text = "Unique molecules";
            Part2Text = "Steps to create molecule";

            Load("inputs/day19.txt");
        }

        override public void Solve()
        {
            string startingMolecule = "";
            List<ReplacementRule> replacementRules = new List<ReplacementRule>();
            HashSet<string> uniqueMolecules = new HashSet<string>();

            foreach (string s in Input)
            {
                if (s.Contains("=>"))
                {
                    // Replacement rule
                    string[] splitted = s.Split(new char[] { ' ', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    replacementRules.Add(new ReplacementRule() { From = splitted[0], To = splitted[1] });
                }
                else if (s.Length > 0)
                {
                    // starting molecule
                    startingMolecule = s;
                }
            }

            foreach(ReplacementRule r in replacementRules)
            {
                int searchIndex = 0;
                int foundIndex;

                while((foundIndex = startingMolecule.IndexOf(r.From, searchIndex)) >= 0)
                {
                    string n = startingMolecule.Substring(0, foundIndex) + r.To + startingMolecule.Substring(foundIndex + r.From.Length);
                    uniqueMolecules.Add(n);
                    searchIndex = foundIndex + r.From.Length;
                }
            }

            Part1Solution = uniqueMolecules.Count.ToString();

            int cnt = 0;
            while (!startingMolecule.Equals("e"))
            {
                foreach (ReplacementRule r in replacementRules)
                {
                    int searchIndex = 0;
                    int foundIndex;

                    if ((foundIndex = startingMolecule.IndexOf(r.To, searchIndex)) >= 0)
                    {
                        string n = startingMolecule.Substring(0, foundIndex) + r.From + startingMolecule.Substring(foundIndex + r.To.Length);
                        cnt++;
                        startingMolecule = n;
                    }
                }
            }
            Part2Solution = cnt.ToString();
        }
    }
}
