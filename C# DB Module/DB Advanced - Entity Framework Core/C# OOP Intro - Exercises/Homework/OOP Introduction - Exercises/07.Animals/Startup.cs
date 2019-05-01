namespace _07.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
