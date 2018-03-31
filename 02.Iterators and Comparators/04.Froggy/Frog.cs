public class Frog
{
    private Lake lake;

    public Frog(Lake lake)
    {
        this.lake = lake;
    }

    public string Jump()
    {
        return string.Join(", ", this.lake);
    }
}
