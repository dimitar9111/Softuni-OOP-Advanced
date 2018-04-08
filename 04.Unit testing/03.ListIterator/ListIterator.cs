using System;
using System.Collections.Generic;

public class ListIterator
{
    private IList<string> collection;
    private int index;

    public ListIterator()
    {
        this.collection = new List<string>();
        this.index = 0;
    }

    public ListIterator(ICollection<string> collection)
        : this()
    {
        this.Collection = new List<string>(collection);
    }

    public IList<string> Collection
    {
        get { return new List<string>(this.collection); }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value cannot be null!");
            }
            this.collection = value;
        }
    }

    public bool Move()
    {
        if (index < this.collection.Count - 1)
        {
            this.index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (index < this.collection.Count - 1)
        {
            return true;
        }

        return false;
    }

    public string Print()
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("Collection contains no elements!");
        }

        return this.collection[index];
    }
}
