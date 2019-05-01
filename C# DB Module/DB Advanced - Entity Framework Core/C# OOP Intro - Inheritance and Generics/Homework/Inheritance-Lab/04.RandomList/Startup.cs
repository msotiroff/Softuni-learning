namespace _04.RandomList
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList()
            {
                "First",
                "Second",
                "Third",
                "Fourth",
                "Fifth"
            };

            Console.WriteLine(list.RandomString());
        }
    }
}
