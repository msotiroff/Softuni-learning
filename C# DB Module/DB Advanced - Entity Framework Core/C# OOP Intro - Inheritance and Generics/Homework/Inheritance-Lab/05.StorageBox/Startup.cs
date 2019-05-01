namespace _05.StorageBox
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var box = new Box<int>();

            for (int i = 0; i < 11; i++)
            {
                box.Add(i);
            }

            Console.WriteLine(box);
        }
    }
}
