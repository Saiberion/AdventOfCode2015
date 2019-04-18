using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    class Ingredient
    {
        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavour { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }

        public Ingredient(int cap, int dur, int fla, int tex, int cal)
        {
            Capacity = cap;
            Durability = dur;
            Flavour = fla;
            Texture = tex;
            Calories = cal;
        }
    }

    public class Day15: Day
    {
        public Day15()
        {
            Part1Text = "Cookie total score";
            Part2Text = "";

            Load("inputs/day15.txt");
        }

        override public void Solve()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            int bestCookieScore = int.MinValue;

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                ingredients.Add(new Ingredient(int.Parse(splitted[2]), int.Parse(splitted[4]), int.Parse(splitted[6]), int.Parse(splitted[8]), int.Parse(splitted[10])));
            }

            for (int i = 0; i < ingredients.Count; i++)
            {

            }

            Part1Solution = bestCookieScore.ToString();
            //Part2Solution = winningPoints.ToString();
        }
    }
}
