namespace P01.EventImplementation
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var dispacher = new Dispatcher();
            var handler = new Handler();

            dispacher.NameChange += handler.OnDispatcherNameChange;

            string newName;
            while ((newName = Console.ReadLine()) != "End")
            {
                dispacher.Name = newName;
            }
        }
    }
}
