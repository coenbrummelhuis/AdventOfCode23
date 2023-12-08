using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace Day4P1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllText("../../input.txt").Split('\n');
            int points = 0;
            foreach (var line in input)
            {
                string[] game = line.Split(':')[1].Split('|');
                
                List<int> winningNumbers = getNumbers(game[0]);
                List<int> ownedNumbers = getNumbers(game[1]);
                int wn = 0;
                foreach (var ownedNumber in ownedNumbers)
                {
                    if (winningNumbers.Contains(ownedNumber))
                    {
                        wn++;
                    }
                }

                int point = wn > 0 ? 1 << (wn - 1) : 0;

                points += point;
                Console.WriteLine(wn);
            }
            Console.WriteLine(points);
        }

        static List<int> getNumbers(string line)
        {
            string number = "";
            List<int> numbers = new List<int>();

            for (int i = 1; i < line.Length; i++)
            {
                if (i % 3 == 0 || i == line.Length)
                {
                    number += line.ToCharArray()[i - 1];
                    numbers.Add(int.Parse(number));
                    number = "";
                }
                else
                {
                    number += line.ToCharArray()[i - 1];
                }
            }
            return numbers;
        }
    }
}