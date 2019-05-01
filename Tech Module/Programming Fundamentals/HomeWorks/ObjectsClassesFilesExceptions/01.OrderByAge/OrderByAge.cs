using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OrderByAge
{
    public class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputParams = input.Split(' ');

                Person currentPerson = new Person()
                {
                    Name = inputParams[0],
                    ID = inputParams[1],
                    Age = int.Parse(inputParams[2])
                };

                allPeople.Add(currentPerson);

                input = Console.ReadLine();
            }


            foreach (var person in allPeople.OrderBy(p => p.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }

        }
    }
}
