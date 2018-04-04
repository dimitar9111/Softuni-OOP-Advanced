using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Models.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);

            return $"{this.Data[1]} retired!";
        }
    }
}
