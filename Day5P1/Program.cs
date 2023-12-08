using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5P1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int id = 0;
            List<string> input = new List<string>(File.ReadAllText("../../input.txt").Split('\n'));
            input = input.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
            foreach (var line in input)
            {
                Console.WriteLine(line);
            }
            // {
            //     if (input[i] == "\r")
            //     {
            //         input.RemoveAt(i);
            //     }
            //     else
            //     {
            //         Console.WriteLine(i + "\t" + input[i]);   
            //     }
            // }
        }
    }
}