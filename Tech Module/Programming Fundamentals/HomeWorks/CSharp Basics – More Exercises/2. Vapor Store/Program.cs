using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vapor_Store
{
    class VaporStore
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            double beginningBalance = currentBalance;

            string gameName = Console.ReadLine();

            while (gameName != "Game Time")
            {
                if (gameName == "OutFall 4")
                {
                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine("Bought OutFall 4");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "CS: OG")
                {
                    if (currentBalance >= 15.99)
                    {
                        currentBalance -= 15.99;
                        Console.WriteLine("Bought CS: OG");

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "Zplinter Zell")
                {
                    if (currentBalance >= 19.99)
                    {
                        currentBalance -= 19.99;
                        Console.WriteLine("Bought Zplinter Zell");

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "Honored 2")
                {
                    if (currentBalance >= 59.99)
                    {
                        currentBalance -= 59.99;
                        Console.WriteLine("Bought Honored 2");


                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "RoverWatch")
                {
                    if (currentBalance >= 29.99)
                    {
                        currentBalance -= 29.99;
                        Console.WriteLine("Bought RoverWatch");

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "RoverWatch Origins Edition")
                {
                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine("Bought RoverWatch Origins Edition");

                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                gameName = Console.ReadLine();
            }

            if (currentBalance > 0)
            {
                double totalSpent = beginningBalance - currentBalance;
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
