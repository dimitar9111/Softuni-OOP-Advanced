public class Box<T>
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
}
