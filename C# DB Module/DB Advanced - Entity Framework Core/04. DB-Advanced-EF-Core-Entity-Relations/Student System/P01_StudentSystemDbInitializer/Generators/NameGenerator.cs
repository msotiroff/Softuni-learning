namespace P01_StudentSystemDbInitializer.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NameGenerator
    {
        private static string[] firstNames =
            { "Edward", "John", "George", "Tom", "Steven", "Mike", "Robert", "James", "Mark", "Donald", "Isaac", "Iosseb" };

        private static string[] lastNames =
            { "Morris", "Milton", "Coors", "Thomas", "Hunter", "Brown", "Hank", "Gorbachov", "Dzhugashvily", "Visaryonovich", "Lomonosov", "Newton"};

        public static string FirstName() => GenerateName(firstNames);
        public static string LastName() => GenerateName(lastNames);

        private static string GenerateName(string[] names)
        {
            Random rnd = new Random();

            int index = rnd.Next(0, names.Length);

            string name = names[index];

            return name;
        }
    }
}
