namespace P01.DangerousFloor
{
    using System;
    using System.Linq;

    public class DangerousFloor
    {
        private static char[][] chessBoard;

        public static void Main(string[] args)
        {
            chessBoard = new char[8][];

            for (int i = 0; i < 8; i++)
            {
                chessBoard[i] = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => char.Parse(s))
                    .ToArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var figure = command[0];
                var startRow = int.Parse(command[1].ToString());
                var startCol = int.Parse(command[2].ToString());
                var destRow = int.Parse(command[4].ToString());
                var destCol = int.Parse(command[5].ToString());

                if (!IsThereSuchPiece(figure, startRow, startCol))
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (!IsValidMove(figure, startRow, startCol, destRow, destCol))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (!IsInBoard(destRow, destCol))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    chessBoard[startRow][startCol] = 'x';
                    chessBoard[destRow][destCol] = figure;
                }
            }
        }
        
        private static bool IsValidMove(char figure, int startRow, int startCol, int destRow, int destCol)
        {
            if ((destRow == startRow && destCol == startCol))
            {
                return false;
            }

            var isValidMove = true;
            
            switch (figure)
            {
                case 'K':
                    if (Math.Abs(destRow - startRow) > 1 || Math.Abs(destCol - startCol) > 1)
                    {
                        isValidMove = false;
                    }
                    break;
                case 'R':
                    if (destRow != startRow && destCol != startCol)
                    {
                        isValidMove = false;
                    }
                    break;
                case 'B':
                    isValidMove = IsAnyValidDiagonalMove(startRow, startCol, destRow, destCol);
                    break;
                case 'Q':

                    if ((destRow == startRow && destCol != startCol) || (destCol == startCol && destRow != startRow))
                    {
                        isValidMove = true;
                    }
                    else
                    {
                        isValidMove = IsAnyValidDiagonalMove(startRow, startCol, destRow, destCol);
                    }
                    break;
                case 'P':
                    if (startCol != destCol || destRow != startRow - 1)
                    {
                        isValidMove = false;
                    }
                    break;
                default:
                    break;
            }

            return isValidMove;
        }

        private static bool IsAnyValidDiagonalMove(int startRow, int startCol, int destRow, int destCol)
        {
            var leftDiagonalIndicator = Math.Abs(startRow - startCol);

            var rightDiagonalIncicator = startRow + startCol;

            if (Math.Abs(destRow - destCol) == leftDiagonalIndicator)
            {
                return true;
            }
            else if (destRow + destCol == rightDiagonalIncicator)
            {
                return true;
            }
            return false;
        }

        private static bool IsInBoard(int row, int col)
        {
            var isInBoundsOfChessBoard = row >= 0
                && row < 8
                && col >= 0
                && col < 8;

            return isInBoundsOfChessBoard;
        }

        private static bool IsThereSuchPiece(char figure, int startRow, int startCol)
        {
            return chessBoard[startRow][startCol] == figure;
        }
    }
}
