namespace Day2P1
{
    internal class Program
    {
        public static Dictionary<String, int> _maxCubes = new Dictionary<string, int>()
        {
            {"red", 12},
            {"green", 13},
            {"blue", 14}
        };
        public static void Main(string[] args)
        {
            int totalid = 0;
            string[] input = File.ReadAllText("../../../input.txt").Split("\n");
            for (int i = 1; i <= input.Length; i++)
            {
                Boolean NotPassed = false;
                Console.WriteLine(i + ": ");
                string line = input[i-1];
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
                        foreach (KeyValuePair<string, int> max in _maxCubes)
                        {
                            if (color.Contains(max.Key))
                            {
                                if (amount > max.Value)
                                {
                                    NotPassed = true;
                                }
                            }
                        }
                        Console.WriteLine("\t\t" + cube);
                    }
                }
                Console.WriteLine(i.ToString() + NotPassed);
                if (!NotPassed)
                {
                    totalid += i;
                }
            }
            Console.WriteLine(totalid);
        }
    }
}