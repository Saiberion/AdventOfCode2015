using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days
{
    class Reindeer
    {
        public int Speed { get; set; }
        public int FlyTime { get; set; }
        public int RestTime { get; set; }
        public int TraveledDistance { get; set; }
        public int PointsScored { get; set; }

        private bool isFlying;
        private int travelTime;

        public Reindeer(int speed, int flyTime, int restTime)
        {
            Speed = speed;
            FlyTime = flyTime;
            RestTime = restTime;

            TraveledDistance = 0;
            PointsScored = 0;
            isFlying = true;
            travelTime = 0;
        }

        public void Travel()
        {
            if (isFlying)
            {
                TraveledDistance += Speed;
                if (++travelTime == FlyTime)
                {
                    isFlying = false;
                    travelTime = 0;
                }
            }
            else
            {
                if (++travelTime == RestTime)
                {
                    isFlying = true;
                    travelTime = 0;
                }
            }
        }
    }

    public class Day14: Day
    {
        public Day14()
        {
            Part1Text = "Winning Distance";
            Part2Text = "Winning Points";

            Load("inputs/day14.txt");
        }

        override public void Solve()
        {
            List<Reindeer> reindeers = new List<Reindeer>();
            int winningDistance = int.MinValue;
            int winningPoints = int.MinValue;

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                reindeers.Add(new Reindeer(int.Parse(splitted[3]), int.Parse(splitted[6]), int.Parse(splitted[13])));
            }

            for (int i = 0; i < 2503; i++)
            {
                Reindeer leading;
                foreach (Reindeer r in reindeers)
                {
                    r.Travel();
                    winningDistance = Math.Max(winningDistance, r.TraveledDistance);
                }

                leading = reindeers[0];
                for(int r = 1; r < reindeers.Count; r++)
                {
                    if (reindeers[r].TraveledDistance > leading.TraveledDistance)
                    {
                        leading = reindeers[r];
                    }
                }
                foreach (Reindeer r in reindeers)
                {
                    if (r.TraveledDistance == leading.TraveledDistance)
                    {
                        winningPoints = Math.Max(winningPoints, ++r.PointsScored);
                    }
                }
            }

            Part1Solution = winningDistance.ToString();
            Part2Solution = winningPoints.ToString();
        }
    }
}
