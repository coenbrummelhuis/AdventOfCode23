using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Day3P1
{
    internal class Program
    {
        private static List<char> symbols = new List<char>()
        {
            '+',
            '*',
            '%',
            '#',
            '=',
            '/',
            '&',
            '@',
            '-',
            '$'
        };
        public static void Main(string[] args)
        {
            int total = 0;
            List<string> rows = new List<string>(File.ReadAllLines("../../input.txt"));
            int index = 0;
            foreach (string row in rows)
            {
                Dictionary<int, int[]> numbers = findNumbers(row);
                foreach (KeyValuePair<int, int[]> n in numbers)
                {
                    if (isHorizontal(row, n.Value))
                    {
                        Console.WriteLine(index + "\t" + n.Value[0] + ": " + n.Value[1] + "-" + n.Value[2]);
                        total += n.Value[0];
                    }
                    else if (isElsewhere(index, n.Value, rows))
                    {
                        Console.WriteLine(index + "\t" + n.Value[0] + ": " + n.Value[1] + "-" + n.Value[2]);
                        total += n.Value[0];
                    }
                    else
                    {
                        Console.WriteLine("\t" + index + "\t" + n.Value[0] + ": " + n.Value[1] + "-" + n.Value[2]);
                    }
                }
                index++;
            }
            Console.WriteLine(total);
        }

        public static Dictionary<int, int[]> findNumbers(string row)
        {
            // first int is first index, second int is the second index
            Dictionary<int, int[]> numberDictionary = new Dictionary<int, int[]>();
            char[] rowArray = row.ToCharArray();
            int start = -1; int end = -1;
            String number = "";
            for (int i = 0; i < rowArray.Length; i++)
            {
                char c = rowArray[i];
                if (char.IsNumber(c))
                {
                    if (start == -1)
                    {
                        start = i;
                        end = i;
                        number += c;
                    }else
                    {
                        number += c;
                        end = i;
                    }
                }else if (end != -1)
                {

                    int[] position =
                    {
                        int.Parse(number), start, end
                    };
                    numberDictionary.Add(numberDictionary.Count, position);
                    start = -1;
                    end = -1;
                    number = "";
                }
            }

            if (start != -1)
            {
                int[] position =
                {
                    int.Parse(number), start, end
                };
                numberDictionary.Add(numberDictionary.Count, position);
                start = -1;
                end = -1;
                number = "";
            }
            return numberDictionary;
        }

        public static Boolean isHorizontal(string row, int[] position)
        {
            int start = position[1];
            int end = position[2];
            char[] rowArray = row.ToCharArray();
            if (start != 0)
            {
                if (SymbolCheck(rowArray[start - 1]) && rowArray[start - 1] != '.')
                {
                    return true;
                }
            }
            if (rowArray.Length == end + 1)
            {
                return false;
            }
            if (SymbolCheck(rowArray[end + 1]) && rowArray[end + 1] != '.')
            {
                return true;
            }
            if (SymbolCheck(rowArray[end + 1]) && rowArray[end + 1] != '.')
            {
                return true;
            }
            return false;
        }

        public static Boolean isElsewhere(int row, int[] position, List<string> rows)
        {
            int start = position[1];
            int end = position[2];
            // Above
            if (row > 0)
            {
                int aboveRowIndex = row - 1;
                string aboveRow = rows[aboveRowIndex];
                for (int i = start - 1; i < end + 2; i++)
                {
                    if (i >= 0 && i <= aboveRow.ToCharArray().Length - 1)
                    {
                        if (SymbolCheck(aboveRow.ToCharArray()[i]) && aboveRow.ToCharArray()[i] != '.')
                        {
                            return true;
                        }
                    }
                }
            }
            
            // below
            if (row < rows.Count - 1)
            {
                int belowRowIndex = row + 1;
                string belowRow = rows[belowRowIndex];
                for (int i = start - 1; i < end + 2; i++)
                {
                    if (i >= 0 && i <= belowRow.ToCharArray().Length - 1)
                    {
                        if (SymbolCheck(belowRow.ToCharArray()[i]) && belowRow.ToCharArray()[i] != '.')
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static Boolean SymbolCheck(char c)
        {
            foreach (char symbol in symbols)
            {
                if (c == symbol)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}