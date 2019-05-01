namespace P02.KnightGame
{
    using System;

    class StartUp
    {
        private static char[][] chessBoard;
        private static int size;
        private static int maxDamagedKnights = 8;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            chessBoard = new char[size][];

            var removedKnights = 0;

            for (int i = 0; i < size; i++)
            {
                chessBoard[i] = Console.ReadLine().ToCharArray();
            }

            while (maxDamagedKnights > 0)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (chessBoard[row][col] == 'K')
                        {
                            int damagedKnights = FindDamagedKnightsCount(row, col);

                            if (damagedKnights == maxDamagedKnights)
                            {
                                chessBoard[row][col] = '0';
                                removedKnights++;
                            }
                        }
                    }
                }

                maxDamagedKnights--;
            }

            Console.WriteLine(removedKnights);
        }

        private static int FindDamagedKnightsCount(int row, int col)
        {
            var damagedKnightsCount = 0;

            if (IsInBoard(row - 2, col - 1) && chessBoard[row - 2][col - 1] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row - 2, col + 1) && chessBoard[row - 2][col + 1] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row - 1, col - 2) && chessBoard[row - 1][col - 2] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row - 1, col + 2) && chessBoard[row - 1][col + 2] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row + 1, col - 2) && chessBoard[row + 1][col - 2] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row + 1, col + 2) && chessBoard[row + 1][col + 2] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row + 2, col - 1) && chessBoard[row + 2][col - 1] == 'K')
            {
                damagedKnightsCount++;
            }
            if (IsInBoard(row + 2, col + 1) && chessBoard[row + 2][col + 1] == 'K')
            {
                damagedKnightsCount++;
            }

            return damagedKnightsCount;
        }

        private static bool IsInBoard(int row, int col)
        {
            return row >= 0
                && row < size
                && col >= 0
                && col < size;
        }
    }
}
