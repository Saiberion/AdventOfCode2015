using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Days
{
    public class Day12 : Day
    {
        public Day12()
        {
            Part1Text = "sum of all numbers";
            Part2Text = "sum of all numbers (skip objects with 'red')";

            Load("inputs/day12.txt");
        }

        int SumUpObject(Dictionary<string, object> obj, bool skipRed)
        {
            int sum = 0;

            if (skipRed && obj.ContainsValue("red"))
            {
                return 0;
            }

            foreach (KeyValuePair<string, object> kvp in obj)
            {
                if (kvp.Value is Dictionary<string, object>)
                {
                    sum += SumUpObject(kvp.Value as Dictionary<string, object>, skipRed);
                }
                else if (kvp.Value is object[])
                {
                    sum += SumUpArray(kvp.Value as object[], skipRed);
                }
                else if (kvp.Value is int)
                {
                    sum += (int)kvp.Value;
                }
            }

            return sum;
        }

        int SumUpArray(object[] arr, bool skipRed)
        {
            int sum = 0;

            foreach(object o in arr)
            {
                if (o is Dictionary<string, object>)
                {
                    sum += SumUpObject(o as Dictionary<string, object>, skipRed);
                }
                else if (o is object[])
                {
                    sum += SumUpArray(o as object[], skipRed);
                }
                else if (o is int)
                {
                    sum += (int)o;
                }
            }

            return sum;
        }

        override public void Solve()
        {
            int sum = 0;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            object jsonInput = serializer.DeserializeObject(Input[0]);

            if (jsonInput is Dictionary<string, object>)
            {
                sum += SumUpObject(jsonInput as Dictionary<string, object>, false);
            }
            else if (jsonInput is object[])
            {
                sum += SumUpArray(jsonInput as object[], false);
            }
            Part1Solution = sum.ToString();

            sum = 0;
            if (jsonInput is Dictionary<string, object>)
            {
                sum += SumUpObject(jsonInput as Dictionary<string, object>, true);
            }
            else if (jsonInput is object[])
            {
                sum += SumUpArray(jsonInput as object[], true);
            }
            Part2Solution = sum.ToString();
        }
    }
}
