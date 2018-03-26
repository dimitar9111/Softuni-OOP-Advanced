using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var list = new List<Box<double>>();

        for (int i = 0; i < n; i++)
        {
            var input = double.Parse(Console.ReadLine());
            var box = new Box<double>(input);
            list.Add(box);
        }

        var testValue = double.Parse(Console.ReadLine());
        var counter = 0;
        foreach (var box in list)
        {
            var result = box.Type.CompareTo(testValue);
            if (result>0)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}
