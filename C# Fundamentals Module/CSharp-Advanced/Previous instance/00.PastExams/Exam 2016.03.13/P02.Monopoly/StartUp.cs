namespace P02.Monopoly
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = dimensions.First();
            var columnsCount = dimensions.Last();

            var matrix = new char[rowsCount][];

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().ToCharArray();
            }
            
            var totalHotelsBought = 0;
            var money = 50;
            var turns = 0;

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                if (rowIndex % 2 == 0)
                {
                    for (int colIndex = 0; colIndex < columnsCount; colIndex++)
                    {
                        var currentCell = matrix[rowIndex][colIndex];

                        switch (currentCell)
                        {
                            case 'H':
                                totalHotelsBought++;
                                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {totalHotelsBought}.");
                                money = 0;
                                break;
                            case 'J':
                                Console.WriteLine($"Gone to jail at turn {turns}.");
                                turns += 2;
                                money += 2 * totalHotelsBought * 10;
                                break;
                            case 'S':
                                var spendMoney = Math.Min((rowIndex + 1) * (colIndex + 1), money);
                                Console.WriteLine($"Spent {spendMoney} money at the shop.");
                                money -= spendMoney;
                                break;
                            default:
                                break;
                        }

                        turns++;
                        money += totalHotelsBought * 10;
                    }
                }
                else
                {
                    for (int colIndex = columnsCount - 1; colIndex >= 0; colIndex--)
                    {
                        var currentCell = matrix[rowIndex][colIndex];

                        switch (currentCell)
                        {
                            case 'H':
                                totalHotelsBought++;
                                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {totalHotelsBought}.");
                                money = 0;
                                break;
                            case 'J':
                                Console.WriteLine($"Gone to jail at turn {turns}.");
                                turns += 2;
                                money += 2 * totalHotelsBought * 10;
                                break;
                            case 'S':
                                var spendMoney = Math.Min((rowIndex + 1) * (colIndex + 1), money);
                                Console.WriteLine($"Spent {spendMoney} money at the shop.");
                                money -= spendMoney;
                                break;
                            default:
                                break;
                        }

                        turns++;
                        money += totalHotelsBought * 10;
                    }
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }
    }
}
