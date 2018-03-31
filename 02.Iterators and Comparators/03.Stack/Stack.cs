using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Stack<T> : IEnumerable<T>
{
    private IList<T> elements;

    public Stack()
    {
        this.elements = new List<T>();
    }

    public void Push(T element)
    {
        this.elements.Add(element);
    }

    public T Pop()
    {
        if (this.elements.Count == 0)
        {
            throw new IndexOutOfRangeException("No elements");
        }
        var element = this.elements.Last();
        this.elements.RemoveAt(elements.Count - 1);
        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.elements.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}
