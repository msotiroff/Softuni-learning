using Animals.Models;
using System;
using System.Collections.Generic;

namespace Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var allAnimals = new List<Animal>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    var animalType = inputLine;
                    var animalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = animalParams[0];
                    int age = int.Parse(animalParams[1]);
                    var gender = animalParams[2];

                    Animal currentAnimal = null;

                    switch (animalType)
                    {
                        case "Dog":
                            currentAnimal = new Dog(name, age, gender);
                            break;
                        case "Cat":
                            currentAnimal = new Cat(name, age, gender);
                            break;
                        case "Frog":
                            currentAnimal = new Frog(name, age, gender);
                            break;
                        case "Kitten":
                            currentAnimal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            currentAnimal = new Tomcat(name, age);
                            break;
                        default:
                            break;
                    }

                    allAnimals.Add(currentAnimal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            allAnimals.ForEach(a => Console.WriteLine(a));
        }
    }
}
