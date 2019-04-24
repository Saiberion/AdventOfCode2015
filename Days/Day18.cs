using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    public class Day18: Day
    {
        public Day18()
        {
            Part1Text = "Active Lights after 100 frames";
            Part2Text = "Active Lights after 100 frames (broken corners)";

            Load("inputs/day18.txt");
        }

        int GetActiveNeighbors(int[,] grid, int x, int y)
        {
            int active = 0;

            if (x > 0)
            {
                active += grid[x - 1, y];
            }
            if (y > 0)
            {
                active += grid[x, y - 1];
            }
            if (x < (grid.GetLength(0) - 1))
            {
                active += grid[x + 1, y];
            }
            if (y < (grid.GetLength(1) - 1))
            {
                active += grid[x, y + 1];
            }
            if ((x > 0) && (y > 0))
            {
                active += grid[x - 1, y - 1];
            }
            if ((x > 0) && (y < (grid.GetLength(1) - 1)))
            {
                active += grid[x - 1, y + 1];
            }
            if ((x < (grid.GetLength(0) - 1)) && (y > 0))
            {
                active += grid[x + 1, y - 1];
            }
            if ((x < (grid.GetLength(0) - 1)) && (y < (grid.GetLength(1) - 1)))
            {
                active += grid[x + 1, y + 1];
            }

            return active;
        }

        int[,] InitializeGrid()
        {
            int cols, rows;
            int[,] grid;
            cols = Input[0].Length;
            rows = Input.Count;

            grid = new int[cols, rows];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (Input[y][x] == '#')
                    {
                        grid[x, y] = 1;
                    }
                    else
                    {
                        grid[x, y] = 0;
                    }
                }
            }

            return grid;
        }

        void Animate(int[,] grid, int frames, bool part2)
        {
            int[,] gridCpy;
            for (int steps = 0; steps < frames; steps++)
            {
                gridCpy = (int[,])grid.Clone();

                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        int activeNeighbors = GetActiveNeighbors(gridCpy, x, y);
                        if ((gridCpy[x, y] == 1) && ((activeNeighbors == 2) || (activeNeighbors == 3)))
                        {
                            grid[x, y] = 1;
                        }
                        else if ((gridCpy[x, y] == 0) && (activeNeighbors == 3))
                        {
                            grid[x, y] = 1;
                        }
                        else
                        {
                            grid[x, y] = 0;
                        }
                    }
                }
                if (part2)
                {
                    grid[0, 0] = 1;
                    grid[grid.GetLength(0) - 1, 0] = 1;
                    grid[0, grid.GetLength(0) - 1] = 1;
                    grid[grid.GetLength(0) - 1, grid.GetLength(0) - 1] = 1;
                }
            }
        }

        int GetActiveLights(int[,] grid)
        {
            int activeLights = 0;
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    activeLights += grid[x, y];
                }
            }
            return activeLights;
        }

        override public void Solve()
        {
            
            int[,] lights;
            
            // Part 1
            lights = InitializeGrid();
            Animate(lights, 100, false);
            Part1Solution = GetActiveLights(lights).ToString();

            // Part 2
            lights = InitializeGrid();
            Animate(lights, 100, true);
            Part2Solution = GetActiveLights(lights).ToString();
        }
    }
}
