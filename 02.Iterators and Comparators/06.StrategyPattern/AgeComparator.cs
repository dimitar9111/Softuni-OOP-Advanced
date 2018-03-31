using System.Collections.Generic;

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        return first.Age.CompareTo(second.Age);
    }
}