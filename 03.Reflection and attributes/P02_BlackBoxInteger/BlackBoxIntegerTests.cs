namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            var instance = (BlackBoxInteger)Activator.CreateInstance(type, true);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var targetField = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split('_');
                var command = tokens[0];
                var parameter = int.Parse(tokens[1]);

                var currentMethod = methods.FirstOrDefault(m => m.Name == command);
                currentMethod.Invoke(instance, new object[] { parameter });

                Console.WriteLine(targetField.GetValue(instance));
            }
        }
    }
}
