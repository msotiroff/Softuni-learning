namespace P03.AnimalFarm
{
    using System;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(chicken);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
