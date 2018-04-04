namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using P03_BarraksWars.Core;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter interpreter = new CommandInterpreter(repository, unitFactory);

            IRunnable engine = new Engine(interpreter);
            engine.Run();
        }
    }
}
