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

            var blackBox = (BlackBoxInteger)Activator.CreateInstance(type, true);

            var allMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var neededField = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var commandParams = inputLine.Split('_');
                var mainCommand = commandParams.First();
                var parameter = int.Parse(commandParams.Last());

                MethodInfo method;

                switch (mainCommand)
                {
                    case "Add":
                        method = allMethods.First(mi => mi.Name == "Add");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    case "Subtract":
                        method = allMethods.First(mi => mi.Name == "Subtract");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    case "Multiply":
                        method = allMethods.First(mi => mi.Name == "Multiply");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    case "Divide":
                        method = allMethods.First(mi => mi.Name == "Divide");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    case "LeftShift":
                        method = allMethods.First(mi => mi.Name == "LeftShift");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    case "RightShift":
                        method = allMethods.First(mi => mi.Name == "RightShift");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    default:
                        break;
                }

                Console.WriteLine(neededField.GetValue(blackBox));
            }
        }
    }
}
