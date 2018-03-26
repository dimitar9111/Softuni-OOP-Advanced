using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : ICustomList<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private List<T> elements;

    public CustomList()
    {
        this.elements = new List<T>();
    }

    public CustomList(IEnumerable<T> sortedList)
    {
        this.elements = new List<T>(sortedList);
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public bool Contains(T element)
    {
        return this.elements.Contains(element);
    }

    public int CountGreaterThan(T element)
    {
        var greaterElements = this.elements.Where(e => e.CompareTo(element) > 0);
        return greaterElements.Count();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.elements.GetEnumerator();
    }

    public T Max()
    {
        return this.elements.Max();
    }

    public T Min()
    {
        return this.elements.Min();
    }

    public T Remove(int index)
    {
        var element = this.elements[index];
        this.elements.RemoveAt(index);

        return element;
    }

    public void Swap(int index1, int index2)
    {
        var firstValue = this.elements[index1];
        var secondValue = this.elements[index2];
        this.elements[index1] = secondValue;
        this.elements[index2] = firstValue;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var element in this.elements)
        {
            sb.AppendLine(element.ToString());
        }
        return sb.ToString().Trim();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
