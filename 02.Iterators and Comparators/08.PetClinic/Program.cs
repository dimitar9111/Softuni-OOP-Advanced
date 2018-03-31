public class Program
{
    public static void Main()
    {
        var controller = new PetClinicController();
        var engine = new Engine(controller);

        engine.Run();
    }
}
