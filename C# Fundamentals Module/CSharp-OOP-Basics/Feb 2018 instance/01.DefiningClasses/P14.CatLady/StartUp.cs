namespace P14.CatLady
{
    using Models.Implementation;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allCats = new List<Cat>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                // Input format: Breed <name> <specific value>
                var catParams = inputLine.Split();
                var catType = catParams[0];
                var catName = catParams[1];
                var catSpecificValue = double.Parse(catParams[2]);

                switch (catType)
                {
                    case "Siamese":
                        allCats.Add(new Siamese(catName, (int)catSpecificValue));
                        break;
                    case "Cymric":
                        allCats.Add(new Cymric(catName, catSpecificValue));
                        break;
                    case "StreetExtraordinaire":
                        allCats.Add(new StreetExtraordinaire(catName, (int)catSpecificValue));
                        break;
                    default:
                        break;
                }
            }

            var catNameToBePrinted = Console.ReadLine();

            var cat = allCats.First(c => c.Name == catNameToBePrinted);

            Console.WriteLine(cat);
        }
    }
}
