using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    public class Day06: Day
    {
        public Day06()
        {
            Part1Text = "Active Lights";
            Part2Text = "Total brightness";

            Load("inputs/day06.txt");
        }

        override public void Solve()
        {
            int[,] lightGrid = new int[1000, 1000];
            int changeVal;
            int activeLights = 0;

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch(splitted[0])
                {
                    case "turn":
                        if (splitted[1].Equals("on"))
                        {
                            changeVal = 1;
                        }
                        else
                        {
                            changeVal = 0;
                        }

                        for(int y = int.Parse(splitted[3]); y <= int.Parse(splitted[6]); y++)
                        {
                            for (int x = int.Parse(splitted[2]); x <= int.Parse(splitted[5]); x++)
                            {
                                lightGrid[x, y] = changeVal;
                            }
                        }
                        break;
                    case "toggle":
                        for (int y = int.Parse(splitted[2]); y <= int.Parse(splitted[5]); y++)
                        {
                            for (int x = int.Parse(splitted[1]); x <= int.Parse(splitted[4]); x++)
                            {
                                lightGrid[x, y] = lightGrid[x, y] == 0 ? 1 : 0;
                            }
                        }
                        break;
                }
            }
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    activeLights += lightGrid[x, y];
                }
            }
            Part1Solution = activeLights.ToString();

            lightGrid = new int[1000, 1000];
            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (splitted[0])
                {
                    case "turn":
                        if (splitted[1].Equals("on"))
                        {
                            changeVal = 1;
                        }
                        else
                        {
                            changeVal = -1;
                        }

                        for (int y = int.Parse(splitted[3]); y <= int.Parse(splitted[6]); y++)
                        {
                            for (int x = int.Parse(splitted[2]); x <= int.Parse(splitted[5]); x++)
                            {
                                lightGrid[x, y] += changeVal;
                                if (lightGrid[x, y] < 0)
                                {
                                    lightGrid[x, y] = 0;
                                }
                            }
                        }
                        break;
                    case "toggle":
                        for (int y = int.Parse(splitted[2]); y <= int.Parse(splitted[5]); y++)
                        {
                            for (int x = int.Parse(splitted[1]); x <= int.Parse(splitted[4]); x++)
                            {
                                lightGrid[x, y] += 2;
                            }
                        }
                        break;
                }
            }
            activeLights = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    activeLights += lightGrid[x, y];
                }
            }
            Part2Solution = activeLights.ToString();
        }
    }
}
