using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var list = new List<Box<int>>();

        for (int i = 0; i < n; i++)
        {
            var input = int.Parse(Console.ReadLine());
            var box = new Box<int>(input);
            list.Add(box);
        }

        var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var firstValue = list[indexes[0]];
        var secondValue = list[indexes[1]];
        list[indexes[0]] = secondValue;
        list[indexes[1]] = firstValue;

        foreach (var box in list)
        {
            Console.WriteLine(box.ToString());
        }
    }
}
