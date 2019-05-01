namespace P01.DangerousFloor
{
    using System;

    class StartUp
    {
        private static readonly int boardSize = 8;
        private static char[][] chessBoard;

        static void Main(string[] args)
        {
            chessBoard = new char[boardSize][];

            for (int row = 0; row < boardSize; row++)
            {
                chessBoard[row] = string.Join(
                    string.Empty, 
                    Console.ReadLine()
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToCharArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var figure = command[0];
                var currentRow = int.Parse(command[1].ToString());
                var currentCol = int.Parse(command[2].ToString());
                var targetRow = int.Parse(command[4].ToString());
                var targetCol = int.Parse(command[5].ToString());

                if (chessBoard[currentRow][currentCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (!IsMovementValid(figure, currentRow, currentCol, targetRow, targetCol))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (!IsInBoard(targetRow, targetCol))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    chessBoard[currentRow][currentCol] = 'x';
                    chessBoard[targetRow][targetCol] = figure;
                }
            }
        }

        private static bool IsInBoard(int row, int col)
        {
            return row >= 0
                && row < boardSize
                && col >= 0
                && col < boardSize;
        }

        private static bool IsMovementValid(char figure, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            var isValid = false;

            var rightDiagonalValid = targetRow + targetCol == currentRow + currentCol;
            var leftDiagonalValid = Math.Abs(targetRow - targetCol) == Math.Abs(currentRow - currentCol);

            var horizontalValid = targetRow == currentRow && targetCol != currentCol;
            var verticalValid = targetRow != currentRow && targetCol == currentCol;

            switch (figure)
            {
                case 'K':
                    isValid = targetRow >= currentRow - 1
                        && targetRow <= currentRow + 1
                        && targetCol >= currentCol - 1
                        && targetCol <= currentCol + 1;
                    break;
                case 'R':
                    isValid = horizontalValid || verticalValid;
                    break;
                case 'B':
                    isValid = rightDiagonalValid || leftDiagonalValid;
                    break;
                case 'Q':
                    isValid = horizontalValid || verticalValid || rightDiagonalValid || leftDiagonalValid;
                    break;
                case 'P':
                    isValid = targetRow == currentRow - 1 && targetCol == currentCol;
                    break;
                default:
                    break;
            }

            return isValid;
        }
    }
}
