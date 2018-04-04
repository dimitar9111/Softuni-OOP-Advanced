using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Models.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var output = this.Repository.Statistics;
            return output;
        }
    }
}
