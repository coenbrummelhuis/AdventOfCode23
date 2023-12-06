using System;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Day1P2
{
    internal class Program
    {
        static string[] letters = new[]
        {
            "oneight": "18",
            "twone": "21",
            "threeight": "38",
            "fiveight": "58",
            "sevenine": "79",
            "eightwo": "82",
            "eighthree",
            "nineight",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            
        };
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("../../input.txt");
            int total = 0;
            foreach (string line in input.Split('\n'))
            {
                string newline = toNumbers(line);
                Console.WriteLine(": " + newline);
                int digitTotal = getDigitTotal(newline);
                Console.WriteLine("\t" + digitTotal);
                total += digitTotal;
            }
            Console.WriteLine(total);
        }

        private static string toNumbers(String line)
        {
            Boolean search = true;
            for (int i = 0; i < letters.Length; i++)
            {
                string letter = letters[i];
                line = line.Replace(letter, (i + 1).ToString());
            }
            return line;
        }

        private static int getDigitTotal(String line)
        {
            int linetotal = 0;
                
            Boolean search = true;
            char[] lineArray = line.ToCharArray();
            int index = 0;
            while (search)
            {
                if (Char.IsNumber(lineArray[index]))
                {
                    linetotal += (int.Parse(lineArray[index].ToString()))*10;
                    search = false;
                }
                else
                {
                    index++;
                }
            }
            search = true;
            char[] newLineArray = lineArray;
            Array.Reverse(newLineArray);
            index = 0;
            while (search)
            {
                if (Char.IsNumber(newLineArray[index]))
                {
                    linetotal += int.Parse(newLineArray[index].ToString());
                    search = false;
                }
                else
                {
                    index++;
                }
            }

            return linetotal;
        }
    }
}