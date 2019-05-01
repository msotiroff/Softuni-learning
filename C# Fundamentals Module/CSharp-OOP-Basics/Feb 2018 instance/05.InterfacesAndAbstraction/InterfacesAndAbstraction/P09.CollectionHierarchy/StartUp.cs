namespace P09.CollectionHierarchy
{
    using Models;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemCollection = new AddRemoveCollection();
            var myCollection = new MyList();

            var addCollBackUp = new StringBuilder();
            var addRemoveCollBackUp = new StringBuilder();
            var myListBackUp = new StringBuilder();

            var itemsToBeAdded = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in itemsToBeAdded)
            {
                var index = addCollection.Add(item);
                addCollBackUp.Append($"{index} ");

                index = addRemCollection.Add(item);
                addRemoveCollBackUp.Append($"{index} ");

                index = myCollection.Add(item);
                myListBackUp.Append($"{index} ");
            }

            Console.WriteLine(addCollBackUp);
            Console.WriteLine(addRemoveCollBackUp);
            Console.WriteLine(myListBackUp);
            
            addRemoveCollBackUp.Clear();
            myListBackUp.Clear();

            var numberOfItemsToBeRemoved = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfItemsToBeRemoved; i++)
            {
                var item = addRemCollection.Remove();
                addRemoveCollBackUp.Append($"{item} ");

                item = myCollection.Remove();
                myListBackUp.Append($"{item} ");
            }

            Console.WriteLine(addRemoveCollBackUp);
            Console.WriteLine(myListBackUp);
        }
    }
}
