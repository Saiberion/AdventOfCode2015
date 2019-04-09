using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    class Happiness
    {
        public string person1;
        public string person2;
        public int happiness;

        public Happiness(string pers1, string pers2, int happ)
        {
            person1 = pers1;
            person2 = pers2;
            happiness = happ;
        }
    }

    public class Day13: Day
    {
        public Day13()
        {
            Part1Text = "Best seating happiness";
            Part2Text = "Best seating happiness (including yourself)";

            Load("inputs/day13.txt");
        }

        internal List<List<string>> seatingOrder = new List<List<string>>();

        void SwapElements(ref string a, ref string b)
        {
            string tmp = a;
            a = b;
            b = tmp;
        }

        void GetAllCombinations(string[] input, int k, int m)
        {
            if (k == m)
            {
                List<string> combination = new List<string>();
                for (int i = 0; i <= m; i++)
                {
                    combination.Add(input[i]);
                }
                seatingOrder.Add(combination);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    SwapElements(ref input[k], ref input[i]);
                    GetAllCombinations(input, k + 1, m);
                    SwapElements(ref input[k], ref input[i]);
                }
            }
        }

        int FindBestHappiness(bool includeYourself)
        {
            int maxHappiness = int.MinValue;

            List<Happiness> happinesses = new List<Happiness>();
            List<string> persons = new List<string>();
            Dictionary<List<string>, int> seatingHappines = new Dictionary<List<string>, int>();
            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (!persons.Contains(splitted[0]))
                {
                    persons.Add(splitted[0]);
                }
                if (!persons.Contains(splitted[10]))
                {
                    persons.Add(splitted[10]);
                }

                int sign = splitted[2].Equals("lose") ? -1 : 1;
                Happiness h = new Happiness(splitted[0], splitted[10], int.Parse(splitted[3]) * sign);
                happinesses.Add(h);
            }
            
            if (includeYourself)
            {
                foreach(string s in persons)
                {
                    happinesses.Add(new Happiness("myself", s, 0));
                    happinesses.Add(new Happiness(s, "myself", 0));
                }
                persons.Add("myself");
            }

            GetAllCombinations(persons.ToArray(), 0, persons.Count - 1);

            foreach (List<string> t in seatingOrder)
            {
                int happ = 0;
                for (int i = 0; i < t.Count - 1; i++)
                {
                    foreach (Happiness h in happinesses)
                    {
                        if (t[i].Equals(h.person1) && t[i + 1].Equals(h.person2))
                        {
                            happ += h.happiness;
                        }

                    }
                }
                foreach (Happiness h in happinesses)
                {
                    if (t[t.Count - 1].Equals(h.person1) && t[0].Equals(h.person2))
                    {
                        happ += h.happiness;
                    }

                }
                for (int i = t.Count - 1; i > 0; i--)
                {
                    foreach (Happiness h in happinesses)
                    {
                        if (t[i].Equals(h.person1) && t[i - 1].Equals(h.person2))
                        {
                            happ += h.happiness;
                        }

                    }
                }
                foreach (Happiness h in happinesses)
                {
                    if (t[0].Equals(h.person1) && t[t.Count - 1].Equals(h.person2))
                    {
                        happ += h.happiness;
                    }

                }
                seatingHappines.Add(t, happ);
            }

            foreach (KeyValuePair<List<string>, int> kvp in seatingHappines)
            {
                maxHappiness = Math.Max(maxHappiness, kvp.Value);
            }

            return maxHappiness;
        }

        override public void Solve()
        {
            Part1Solution = FindBestHappiness(false).ToString();
            seatingOrder.Clear();
            Part2Solution = FindBestHappiness(true).ToString();
        }
    }
}
