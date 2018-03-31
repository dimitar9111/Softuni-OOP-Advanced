using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var person = new Person(input[0], int.Parse(input[1]));
            people.Add(person);
        }

        var sortedByName = new SortedSet<Person>(people, new NameComparator());
        var sortedByAge = new SortedSet<Person>(people, new AgeComparator());

        foreach (var person in sortedByName)
        {
            Console.WriteLine(person.ToString());
        }

        foreach (var person in sortedByAge)
        {
            Console.WriteLine(person.ToString());
        }
    }
}
