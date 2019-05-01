using System;
using System.Text;

public class StartUp
{
    public static void Main(string[] args)
    {
        Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
        Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
        Book bookThree = new Book("The Documents in the Case", 1930);

        BookComparator bc = new BookComparator();

        Console.WriteLine(bc.Compare(bookOne, bookTwo));
        Console.WriteLine(bc.Compare(bookTwo, bookThree));
        Console.WriteLine(bc.Compare(bookThree, bookOne));
        Console.WriteLine(bc.Compare(bookOne, bookOne));
    }
}
