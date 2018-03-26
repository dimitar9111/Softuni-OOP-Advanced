using System;

public class Box<T>
    where T : IComparable
{
    public Box(T type)
    {
        this.Type = type;
    }

    public T Type { get; private set; }

    public override string ToString()
    {
        return $"{this.Type.GetType().FullName}: {this.Type}";
    }

    public int CompareTo(T value)
    {
        return this.Type.CompareTo(value);

    }
}
