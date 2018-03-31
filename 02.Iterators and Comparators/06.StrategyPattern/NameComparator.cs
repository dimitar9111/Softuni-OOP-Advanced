using System.Collections.Generic;
using System.Linq;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        var result = first.Name.Length.CompareTo(second.Name.Length);
        if (result == 0)
        {
            result = first.Name.ToLower().First().CompareTo(second.Name.ToLower().First());
        }

        return result;
    }
}