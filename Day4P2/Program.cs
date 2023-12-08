using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Runtime.ConstrainedExecution;

namespace Day4P2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllText("../../input.txt").Split('\n');
            List<int> ticketWinnings = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                ticketWinnings.Add(1);
            }

            for (int i = 0; i < 10; i++)
            {
                ticketWinnings.Add(0);
            }
            for (int i = 0; i < input.Length; i++)
            {
                int winnings = findWinnings(input[i]);
                for (int j = 1; j <= winnings; j++)
                {
                    ticketWinnings[i + j] += ticketWinnings[i];
                    
                }
                
            }
            int tickets = 0;
            foreach (int i in ticketWinnings)
            {
                tickets += i;
            }
            Console.WriteLine(tickets);
        }

        static int findWinnings(string line)
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

            // int point = wn > 0 ? 1 << (wn - 1) : 0;
            return wn;
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