using System;

public class Program
{
    public static void Main()
    {
        var customList = new CustomList<string>();

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split();
            switch (tokens[0])
            {
                case "Add":
                    customList.Add(tokens[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(tokens[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(tokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    Console.WriteLine(customList.ToString());
                    break;
                case "Sort":
                    customList = Sorter.Sort(customList);
                    break;
            }

        }
    }
}
