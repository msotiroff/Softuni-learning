namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Client.Utilities;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            CredentialsChecker.CheckLogin();

            string townName = commandArgs[1];
            string country = commandArgs[2];

            using (var db = new PhotoShareContext())
            {
                var isTownExisting = db
                    .Towns
                    .Any(t => t.Name == townName);

                if (isTownExisting)
                {
                    throw new ArgumentException($"Town {townName} was already added!");
                }

                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                db.Towns.Add(town);
                db.SaveChanges();

                return $"Town {town.Name} was added successfully!";
            }
        }
    }
}
