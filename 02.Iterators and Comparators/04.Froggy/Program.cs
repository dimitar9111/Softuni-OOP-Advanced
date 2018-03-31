using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var stones = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

        var lake = new Lake(stones);
        var frog = new Frog(lake);

        Console.WriteLine(frog.Jump());
    }
}