using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static ListyIterator<string> myList;

    public static void Main()
    {
        var input = Console.ReadLine();
        var listParams = input.Split().Skip(1).ToList();
        myList = new ListyIterator<string>(listParams);

        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Move":
                    Console.WriteLine(myList.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(myList.HasNext());
                    break;
                case "Print":
                    try
                    {
                        Console.WriteLine(myList.Print());
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }
    }
}
