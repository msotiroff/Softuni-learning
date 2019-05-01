namespace P06.Animals
{
    using Models;
    using System;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string animalType;
            string[] validAnimals = new string[] { "Dog", "Cat", "Frog", "Tomcat", "Kitten" };

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalParams = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string name = animalParams[0];
                    int age = int.Parse(animalParams[1]);
                    string gender = string.Empty;
                    if (animalParams.Length > 2)
                    {
                        gender = animalParams[2];
                    }

                    if (animalType == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        result.AppendLine(dog.ToString());
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        result.AppendLine(frog.ToString());
                    }
                    else if (animalType == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        result.AppendLine(cat.ToString());
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        result.AppendLine(tomcat.ToString());
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        result.AppendLine(kitten.ToString());
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }

                if (!validAnimals.Contains(animalType))
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Console.Write(result);
        }
    }
}



//namespace P06.Animals
//{
//    using Contracts;
//    using Models;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    public class StartUp
//    {
//        public static void Main(string[] args)
//        {
//            var validAnimals = new string[] { "Dog", "Cat", "Frog", "Tomcat", "Kitten" };

//            var allAnimals = new List<ISoundProducable>();

//            string inputLine;
//            while ((inputLine = Console.ReadLine()) != "Beast!")
//            {
//                var animalType = inputLine;

//                try
//                {
//                    var animalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//                    var name = animalParams[0];
//                    int age = int.Parse(animalParams[1]);
//                    var gender = string.Empty;
//                    if (animalParams.Length > 2)
//                    {
//                        gender = animalParams[2];
//                    }

//                    ISoundProducable currentAnimal = null;

//                    switch (animalType)
//                    {
//                        case "Dog":
//                            currentAnimal = new Dog(name, age, gender);
//                            break;
//                        case "Cat":
//                            currentAnimal = new Cat(name, age, gender);
//                            break;
//                        case "Frog":
//                            currentAnimal = new Frog(name, age, gender);
//                            break;
//                        case "Kitten":
//                            currentAnimal = new Kitten(name, age);
//                            break;
//                        case "Tomcat":
//                            currentAnimal = new Tomcat(name, age);
//                            break;
//                        default:
//                            break;
//                    }

//                    allAnimals.Add(currentAnimal);
//                }
//                catch (ArgumentException ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//                catch (FormatException)
//                {
//                    Console.WriteLine("Invalid input!");
//                }

//                if (!validAnimals.Contains(animalType))
//                {
//                    Console.WriteLine("Invalid input!");
//                }
//            }

//            allAnimals.ForEach(a => Console.WriteLine(a));
//        }
//    }
//}
