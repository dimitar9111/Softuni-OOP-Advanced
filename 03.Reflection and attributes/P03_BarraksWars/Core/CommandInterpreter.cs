using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandEnding = "Command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var firstLetter = commandName.ToUpper().First();
            var titleCaseCommandName = $"{firstLetter}{string.Join("", commandName.Skip(1))}{commandEnding}";

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == titleCaseCommandName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] parameters =
            {
                data,
                this.repository,
                this.unitFactory
            };

            var commandInstance = (IExecutable)Activator.CreateInstance(commandType, parameters);
            return commandInstance;
        }
    }
}
