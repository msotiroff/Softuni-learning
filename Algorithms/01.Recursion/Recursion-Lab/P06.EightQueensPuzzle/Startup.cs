namespace P06.EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static int foundSolutions = 0;
        private static int size = 7;
        private static bool[,] chessBoard = new bool[size, size];

        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedColumns = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PutQueens(0);

            Console.WriteLine("Solutions count: " + foundSolutions);
        }

        private static void PutQueens(int row)
        {
            if (row == size)
            {
                PrintChessBoard();
            }
            else
            {
                for (int col = 0; col < size; col++)
                {
                    if (CanPutQueenOnCell(row, col))
                    {
                        MarkAttackedCells(row, col);
                        PutQueens(row + 1);
                        UnmarkAttackedCells(row, col);
                    }
                }
            }
        }

        private static void UnmarkAttackedCells(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(row + col);
            attackedRightDiagonals.Remove(row - col);

            chessBoard[row, col] = false;
        }

        private static void MarkAttackedCells(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(row + col);
            attackedRightDiagonals.Add(row - col);
            chessBoard[row, col] = true;
        }

        private static bool CanPutQueenOnCell(int row, int col)
        {
            var isCellFree = !attackedRows.Contains(row)
                && !attackedColumns.Contains(col)
                && !attackedLeftDiagonals.Contains(row + col)
                && !attackedRightDiagonals.Contains(row - col);

            return isCellFree;
        }

        private static void PrintChessBoard()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(chessBoard[row, col] ? "* " : "- ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            foundSolutions++;
        }
    }
}
