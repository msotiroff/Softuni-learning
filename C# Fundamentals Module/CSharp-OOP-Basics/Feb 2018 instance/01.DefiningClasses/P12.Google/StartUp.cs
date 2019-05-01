using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var allPeople = new HashSet<Person>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var inputParams = inputLine.Split();

            var personName = inputParams[0];
            var entityToBeParsed = inputParams[1];
            var entityArgs = inputParams.Skip(2).ToArray();

            if (!allPeople.Any(p => p.Name == personName))
            {
                var personToBeCreated = new Person(personName);
                allPeople.Add(personToBeCreated);
            }

            var person = allPeople.First(p => p.Name == personName);

            switch (entityToBeParsed)
            {
                case "company":
                    var companyName = entityArgs[0];
                    var department = entityArgs[1];
                    var salary = decimal.Parse(entityArgs[2]);
                    var company = new Company(companyName, department, salary);
                    person.Company = company;
                    break;
                case "pokemon":
                    var pokemonName = entityArgs[0];
                    var pokemonType = entityArgs[1];
                    var pokemon = new Pokemon(pokemonName, pokemonType);
                    person.Pokemons.Add(pokemon);
                    break;
                case "parents":
                    var parentName = entityArgs[0];
                    var parentBirthDay = entityArgs[1];
                    var parent = new Person(parentName, parentBirthDay);
                    person.Parents.Add(parent);
                    break;
                case "children":
                    var childName = entityArgs[0];
                    var childBirthDay = entityArgs[1];
                    var child = new Person(childName, childBirthDay);
                    person.Children.Add(child);
                    break;
                case "car":
                    var carModel = entityArgs[0];
                    var carSpeed = int.Parse(entityArgs[1]);
                    var car = new Car(carModel, carSpeed);
                    person.Car = car;
                    break;
                default:
                    break;
            }
        }

        var personFilterName = Console.ReadLine();

        var personToVisualize = allPeople.FirstOrDefault(p => p.Name == personFilterName);

        Console.WriteLine(personToVisualize);
    }
}