namespace P02.KnightGame
{
    using System;
    using System.Collections.Generic;

    public class KnightGame
    {
        private static int result;
        private static char[][] desk;
        private static int dimenssions;

        public static void Main(string[] args)
        {
            dimenssions = int.Parse(Console.ReadLine());
            result = 0;
            desk = new char[dimenssions][];
            InitializeDeskFields();

            for (int mortalBlows = 8; mortalBlows > 0; mortalBlows--)
            {
                for (int row = 0; row < dimenssions; row++)
                {
                    for (int col = 0; col < dimenssions; col++)
                    {
                        if (desk[row][col] == 'K')
                        {
                            CheckPossibleAttacks(row, col, mortalBlows);
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static void CheckPossibleAttacks(int row, int col, int mortalBlows)
        {
            var killed = 0;

            var possibleMoves = new List<Field>()
            {
                new Field(row - 2, col - 1), // up-left
                new Field(row - 2, col + 1), // up-right
                new Field(row - 1, col - 2), // left-up
                new Field(row - 1, col + 2), // right-up
                new Field(row + 2, col - 1), // down-left
                new Field(row + 2, col + 1), // down-right
                new Field(row + 1, col - 2), // left-down
                new Field(row + 1, col + 2), // right-down
            };

            foreach (var field in possibleMoves)
            {
                if (IsInBoundsOfDesk(field))
                {
                    if (desk[field.Row][field.Column] == 'K')
                    {
                        killed++;
                    }
                }
            }

            // Removes the knight with maximum killed another knights:
            if (killed == mortalBlows)
            {
                desk[row][col] = '0';
                result++;
            }
        }

        private static bool IsInBoundsOfDesk(Field field)
        {
            return field.Row >= 0 
                && field.Row < dimenssions 
                && field.Column >= 0 
                && field.Column < dimenssions;
        }

        private static void InitializeDeskFields()
        {
            for (int row = 0; row < dimenssions; row++)
            {
                desk[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
