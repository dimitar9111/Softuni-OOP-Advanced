using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> collection;
    private int index;

    public ListyIterator(IList<T> collection)
    {
        this.collection = collection;
        this.index = 0;
    }

    public bool Move()
    {
        if (index >= collection.Count - 1)
        {
            return false;
        }

        index++;
        return true;
    }

    public bool HasNext()
    {
        if (index >= collection.Count - 1)
        {
            return false;
        }
        return true;
    }

    public T Print()
    {
        if (this.collection.Count == 0)
        {
            throw new IndexOutOfRangeException("Invalid Operation!");
        }
        return this.collection[this.index];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
