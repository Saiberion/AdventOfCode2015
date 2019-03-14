using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    public class Day04: Day
    {
        public Day04()
        {
            Part1Text = "Lowest AdventCoin Hash (5 zeroes)";
            Part2Text = "Lowest AdventCoin Hash (6 zeroes)";

            Load("inputs/day04.txt");
        }

        override public void Solve()
        {
            MD5Managed md5 = new MD5Managed();
            string key = Input[0];
            byte[] hash;

            int index = 1;
            while(true)
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(key + index));

                if ((hash[0] == 0) && (hash[1] == 0) && (hash[2] <= 0x0f))
                {
                    Part1Solution = index.ToString();
                    break;
                }

                index++;
            }

            while (true)
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(key + index));

                if ((hash[0] == 0) && (hash[1] == 0) && (hash[2] == 0))
                {
                    Part2Solution = index.ToString();
                    break;
                }

                index++;
            }
        }
    }
}
