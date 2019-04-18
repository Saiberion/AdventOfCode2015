using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day16: Day
    {
        public Day16()
        {
            Part1Text = "Gift from Sue";
            Part2Text = "Gift from Sue (really)";

            Load("inputs/day16.txt");
        }

        override public void Solve()
        {
            List<Dictionary<string, int>> sues = new List<Dictionary<string, int>>();

            foreach (string s in Input)
            {
                Dictionary<string, int> properties = new Dictionary<string, int>();
                string[] splitted = s.Split(new char[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);

                properties.Add(splitted[0], int.Parse(splitted[1]));
                properties.Add(splitted[2], int.Parse(splitted[3]));
                properties.Add(splitted[4], int.Parse(splitted[5]));
                properties.Add(splitted[6], int.Parse(splitted[7]));
                sues.Add(properties);
            }

            for(int i = 0; i < sues.Count; i++)
            {
                if (sues[i].ContainsKey("children"))
                {
                    if (sues[i]["children"] != 3)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("cats"))
                {
                    if (sues[i]["cats"] != 7)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("samoyeds"))
                {
                    if (sues[i]["samoyeds"] != 2)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("pomeranians"))
                {
                    if (sues[i]["pomeranians"] != 3)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("akitas"))
                {
                    if (sues[i]["akitas"] != 0)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("vizslas"))
                {
                    if (sues[i]["vizslas"] != 0)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("goldfish"))
                {
                    if (sues[i]["goldfish"] != 5)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("trees"))
                {
                    if (sues[i]["trees"] != 3)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("cars"))
                {
                    if (sues[i]["cars"] != 2)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("perfumes"))
                {
                    if (sues[i]["perfumes"] != 1)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
            }

            Part1Solution = sues[0]["Sue"].ToString();

            sues.Clear();

            foreach (string s in Input)
            {
                Dictionary<string, int> properties = new Dictionary<string, int>();
                string[] splitted = s.Split(new char[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);

                properties.Add(splitted[0], int.Parse(splitted[1]));
                properties.Add(splitted[2], int.Parse(splitted[3]));
                properties.Add(splitted[4], int.Parse(splitted[5]));
                properties.Add(splitted[6], int.Parse(splitted[7]));
                sues.Add(properties);
            }

            for (int i = 0; i < sues.Count; i++)
            {
                if (sues[i].ContainsKey("children"))
                {
                    if (sues[i]["children"] != 3)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("cats"))
                {
                    if (sues[i]["cats"] <= 7)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("samoyeds"))
                {
                    if (sues[i]["samoyeds"] != 2)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("pomeranians"))
                {
                    if (sues[i]["pomeranians"] >= 3)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("akitas"))
                {
                    if (sues[i]["akitas"] != 0)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("vizslas"))
                {
                    if (sues[i]["vizslas"] != 0)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("goldfish"))
                {
                    if (sues[i]["goldfish"] >= 5)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("trees"))
                {
                    if (sues[i]["trees"] <= 3)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("cars"))
                {
                    if (sues[i]["cars"] != 2)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
                if (sues[i].ContainsKey("perfumes"))
                {
                    if (sues[i]["perfumes"] != 1)
                    {
                        sues.Remove(sues[i]);
                        i--;
                        continue;
                    }
                }
            }

            Part2Solution = sues[0]["Sue"].ToString();
        }
    }
}
