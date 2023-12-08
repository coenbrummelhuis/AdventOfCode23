using System;
using System.Collections.Generic;
using System.IO;

namespace Day3P2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> rows = new List<string>(File.ReadAllLines("../../input.txt"));
            int[][] gearPositions = new int[5][2];
            int index = 0;
            foreach (string row in rows)
            {
                List<int> gears = findGears(row);
                foreach (var gear in gears)
                {
                    gearPositions.Add(index, gear);
                }

                index++;
            }
        }

        public static List<int> findGears(string row)
        {
            List<int> gearPositions = new List<int>();
            char[] rowArray = row.ToCharArray();
            for (int i = 0; i < rowArray.Length; i++)
            {
                char c = rowArray[i];
                if (c == '*')
                {
                    gearPositions.Add(i);
                }
            }
            return gearPositions;
        }
    }
}