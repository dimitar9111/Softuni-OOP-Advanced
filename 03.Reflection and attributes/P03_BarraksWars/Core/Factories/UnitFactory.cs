namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitModelsNameSpace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            var type = Type.GetType(UnitModelsNameSpace + unitType);
            var unit = (IUnit)Activator.CreateInstance(type);

            return unit;
        }
    }
}
