using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Day1
{
    
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("..\\..\\input.txt");
            int total = 0;
            foreach (string line in input.Split('\n'))
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
                
                Array.Reverse(lineArray);
                index = 0;
                while (search)
                {
                    if (Char.IsNumber(lineArray[index]))
                    {
                        linetotal += int.Parse(lineArray[index].ToString());
                        search = false;
                    }
                    else
                    {
                        index++;
                    }
                }

                total += linetotal;
            }
            Console.WriteLine(total);
        }
    }
}