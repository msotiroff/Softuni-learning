namespace WildFarm
{
    using Models.Animals;
    using Models.Animals.AbstractTypes;
    using Models.Foods;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                var animalParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var foodParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var animalType = animalParams[0];
                var animalName = animalParams[1];
                var animalWeight = double.Parse(animalParams[2]);
                var animalLivingRegion = animalParams[3];

                var foodType = foodParams.First();
                var foodQuantity = int.Parse(foodParams.Last());

                Food food = null;
                if (foodType.Equals("Vegetable"))
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType.Equals("Meat"))
                {
                    food = new Meat(foodQuantity);
                }

                Animal animal = null;

                switch (animalType)
                {
                    case "Cat":
                        var catBreed = animalParams[4];
                        animal = new Cat(animalName, animalWeight, animalLivingRegion, catBreed);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalName, animalWeight, animalLivingRegion);
                        break;
                    case "Zebra":
                        animal = new Zebra(animalName, animalWeight, animalLivingRegion);
                        break;
                    case "Mouse":
                        animal = new Mouse(animalName, animalWeight, animalLivingRegion);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(animal.MakeSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(animal);
            }
        }
    }
}
