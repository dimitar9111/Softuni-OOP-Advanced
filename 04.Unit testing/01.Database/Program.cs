public class Program
{
    public static void Main()
    {
        var values = new int[16];

        var db = new Database(values);

        db.Remove();
    }
}
