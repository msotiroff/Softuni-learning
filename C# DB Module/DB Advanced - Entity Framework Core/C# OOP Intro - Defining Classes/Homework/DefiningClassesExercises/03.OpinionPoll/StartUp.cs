using System;
using System.Collections.Generic;
using System.Linq;
class StartUp
{
    static void Main(string[] args)
    {
        var allPeople = new List<Person>();

        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] inputParams = Console.ReadLine().Split(' ').ToArray();
            string name = inputParams[0];
            int age = int.Parse(inputParams[1]);

            Person currentPerson = new Person(name, age);

            allPeople.Add(currentPerson);
        }

        foreach (var person in allPeople.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
