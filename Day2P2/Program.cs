namespace Day2P2
{

    internal class Program
    {

        public static void Main(string[] args)
        {
            string[] input = File.ReadAllText("../../../input.txt").Split("\n");
            int totalpower = 0;
            for (int i = 1; i <= input.Length; i++)
            {
                string line = input[i-1];
                int[] maxvalues = new int[]
                {
                    1,1,1
                };
                string lineDetails = line.Split(": ")[1];
                string[] games = lineDetails.Split("; ");
                foreach (string game in games)
                {
                    Console.WriteLine("\t" + game);
                    string[] cubedetails = game.Split(", ");
                    foreach (string cube in cubedetails)
                    {
                        int amount = int.Parse(cube.Split(" ")[0]);
                        string color = cube.Split(" ")[1];
                        switch (color)
                        {
                            case "red":
                                if (amount > maxvalues[0])
                                {
                                    maxvalues[0] = amount;
                                }
                                break;
                            case "green":
                                if (amount > maxvalues[1])
                                {
                                    maxvalues[1] = amount;
                                }
                                break;
                            case "blue":
                                if (amount > maxvalues[2])
                                {
                                    maxvalues[2] = amount;
                                }
                                break;
                        }
                    }
                }
                Console.WriteLine("\tFewest: ");
                foreach (int max in maxvalues)
                {
                    Console.WriteLine("\t\t" + max);
                }
                
                int power = maxvalues[0] * maxvalues[1] * maxvalues[2];
                totalpower += power;
            }
            Console.WriteLine(totalpower);
        }
    }
}