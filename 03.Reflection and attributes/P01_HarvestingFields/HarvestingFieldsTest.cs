namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);
            var fields = type.GetFields(BindingFlags.Instance |
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] selectedFields = fields;

                switch (input)
                {
                    case "private":
                        selectedFields = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        selectedFields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        selectedFields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                }

                foreach (var field in selectedFields)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
