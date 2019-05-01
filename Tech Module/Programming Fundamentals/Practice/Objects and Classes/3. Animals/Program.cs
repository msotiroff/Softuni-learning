using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Animals
{
    public class Animals
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            List<Dog> allDogs = new List<Dog>();
            List<string> dogNames = new List<string>();
            List<Cat> allCats = new List<Cat>();
            List<string> catNames = new List<string>();
            List<Snake> allSnakes = new List<Snake>();
            List<string> snakeNames = new List<string>();


            while (inputLine != "I'm your Huckleberry")
            {
                string[] inputParameters = inputLine
                    .Split(' ')
                    .ToArray();

                DistributeAnimals(allDogs, dogNames, allCats, catNames, allSnakes, snakeNames, inputParameters);

                inputLine = Console.ReadLine();
            }
            
            PrintResult(allDogs, allCats, allSnakes);
        }

        public static void PrintResult(List<Dog> allDogs, List<Cat> allCats, List<Snake> allSnakes)
        {
            foreach (var dog in allDogs)
            {
                Console.WriteLine($"Dog: {dog.Name}, Age: {dog.Age}, Number Of Legs: {dog.NumberOfLegs}");
            }
            foreach (var cat in allCats)
            {
                Console.WriteLine($"Cat: {cat.Name}, Age: {cat.Age}, IQ: {cat.IntelligenceQuotient}");
            }
            foreach (var snake in allSnakes)
            {
                Console.WriteLine($"Snake: {snake.Name}, Age: {snake.Age}, Cruelty: {snake.CrueltyCoefficient}");
            }
        }

        public static void DistributeAnimals(List<Dog> allDogs, List<string> dogNames, List<Cat> allCats, List<string> catNames, List<Snake> allSnakes, List<string> snakeNames, string[] inputParameters)
        {
            if (inputParameters[0] == "talk")
            {
                if (dogNames.Contains(inputParameters[1]))
                {
                    Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
                }
                else if (catNames.Contains(inputParameters[1]))
                {
                    Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
                }
                else if (snakeNames.Contains(inputParameters[1]))
                {
                    Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
                }
            }
            else
            {
                string currentClass = inputParameters[0];
                string currentName = inputParameters[1];
                int currentAge = int.Parse(inputParameters[2]);
                int currentParam = int.Parse(inputParameters[3]);

                if (currentClass == "Dog")
                {
                    Dog currentDog = new Dog
                    {
                        Name = currentName,
                        Age = currentAge,
                        NumberOfLegs = currentParam
                    };
                    allDogs.Add(currentDog);
                    dogNames.Add(currentName);
                }
                else if (currentClass == "Cat")
                {
                    Cat currentCat = new Cat
                    {
                        Name = currentName,
                        Age = currentAge,
                        IntelligenceQuotient = currentParam
                    };
                    allCats.Add(currentCat);
                    catNames.Add(currentName);
                }
                else if (currentClass == "Snake")
                {
                    Snake currentSnake = new Snake
                    {
                        Name = currentName,
                        Age = currentAge,
                        CrueltyCoefficient = currentParam
                    };
                    allSnakes.Add(currentSnake);
                    snakeNames.Add(currentName);
                }
            }
        }
    }
}
