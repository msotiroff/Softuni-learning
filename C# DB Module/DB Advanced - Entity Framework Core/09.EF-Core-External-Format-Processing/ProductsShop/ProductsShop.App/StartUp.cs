namespace ProductsShop.App
{
    using System;
    using System.IO;
    using ProductsShop.App.Selectors;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Wellcome.");
            string wellcome = File.ReadAllText("Wellcome.txt");

            while (true)
            {
                Console.WriteLine(wellcome);
                Console.Write("Make your choice: ");

                string command = Console.ReadLine();
                Console.WriteLine(command != "0" ? "Loading..." : string.Empty);
                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "0":
                            Environment.Exit(0);
                            break;
                        case "1":
                            output = DbInitializer.ResetDatabase();
                            break;
                        case "2":
                            output = DbInitializer.SeedDataFromJson();
                            break;
                        case "3":
                            output = JsonSelector.ExportData();
                            break;
                        case "4":
                            output = DbInitializer.SeedDataFromXml();
                            break;
                        case "5":
                            output = XmlSelector.ExportData();
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }

                    Console.Clear();
                    Console.WriteLine(output);
                    Console.WriteLine();
                    Console.WriteLine(new string('=', 15));
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.GetBaseException().Message);
                }
            }
        }
    }
}
