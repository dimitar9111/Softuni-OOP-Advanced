using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        var people = new List<Person>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split();
            var person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
            people.Add(person);
        }

        var index = int.Parse(Console.ReadLine());
        index--;

        var equalPeople = 0;
        for (int i = 0; i < people.Count; i++)
        {
            if (people[index].CompareTo(people[i]) == 0)
            {
                equalPeople++;
            }
        }

        if (equalPeople < 2)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
        }
    }
}
