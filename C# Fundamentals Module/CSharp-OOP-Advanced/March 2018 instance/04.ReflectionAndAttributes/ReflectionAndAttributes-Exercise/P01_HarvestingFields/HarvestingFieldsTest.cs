 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                var result = string.Empty;

                switch (command)
                {
                    case "private":
                        result = GetPrivateFields();
                        break;
                    case "protected":
                        result = GetProtectedFields();
                        break;
                    case "public":
                        result = GetPublicFields();
                        break;
                    case "all":
                        result = GetAllFields();
                        break;
                    default:
                        break;
                }

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
        }

        private static string GetAllFields()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .ToList()
                .ForEach(fi => builder
                    .AppendLine($"{fi.Attributes.ToString().ToLower()} {fi.FieldType.Name} {fi.Name}"));

            var result = builder.ToString().Replace("family", "protected").TrimEnd();

            return result;
        }

        private static string GetPublicFields()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields()
                .ToList()
                .ForEach(fi => builder
                    .AppendLine($"{fi.Attributes.ToString().ToLower()} {fi.FieldType.Name} {fi.Name}"));

            var result = builder.ToString().TrimEnd();

            return result;
        }

        private static string GetProtectedFields()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.IsFamily)
                .ToList()
                .ForEach(fi => builder
                    .AppendLine($"{fi.Attributes.ToString().ToLower()} {fi.FieldType.Name} {fi.Name}"));

            var result = builder.ToString().Replace("family", "protected").TrimEnd();

            return result;
        }

        private static string GetPrivateFields()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => !f.IsFamily)
                .ToList()
                .ForEach(fi => builder
                    .AppendLine($"{fi.Attributes.ToString().ToLower()} {fi.FieldType.Name} {fi.Name}"));

            var result = builder.ToString().TrimEnd();

            return result;
        }
    }
}
