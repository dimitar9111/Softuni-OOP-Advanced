using System;
using System.Linq;

public class Sorter
{
    public static CustomList<T> Sort<T>(CustomList<T> customList) where T : IComparable<T>
    {
        var sortedList = customList.OrderBy(e => e);
        return new CustomList<T>(sortedList);
    }
}