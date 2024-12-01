namespace Advent_of_Code
{
    public static class Day1
    {
        public static void Run()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var (list1, list2) = LoadListsFromFile("C:/input.txt");

            list1.Sort();
            list2.Sort();
            var pairDifferences = list1.Zip(list2, (x, y) => Math.Abs(x - y));
            int totalSum = pairDifferences.Sum();

            Console.WriteLine("[Day 1] Part 1: " + totalSum);
        }

        private static void Part2()
        {
            var (list1, list2) = LoadListsFromFile("C:/input.txt");
            var list2Lookup = list2.ToLookup(n => n);

            int similarityScore = 0;

            foreach (int num in list1)
            {
                int count = list2Lookup[num].Count();
                similarityScore += count * num;
            }

            Console.WriteLine("[Day 1] Part 2: " + similarityScore);
        }

        private static (List<int> list1, List<int> list2) LoadListsFromFile(string filePath)
        {
            List<int> list1 = [];
            List<int> list2 = [];

            var numbers = File.ReadLines(filePath)
             .Select(line => line.Split("   "))
             .Where(parts => parts.Length >= 2)
             .Select(parts => new
             {
                 Num1 = int.Parse(parts[0]),
                 Num2 = int.Parse(parts[1])
             });

            foreach (var n in numbers)
            {
                list1.Add(n.Num1);
                list2.Add(n.Num2);
            }

            return (list1, list2);
        }
    }
}
