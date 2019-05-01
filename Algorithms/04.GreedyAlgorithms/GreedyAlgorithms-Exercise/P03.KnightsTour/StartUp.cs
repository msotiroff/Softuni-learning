namespace P03.KnightsTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Cell> chessBoard;
        private static int turnCounter;
        private static int unvisitedCells;

        public static void Main()
        {
            chessBoard = new List<Cell>();

            var size = int.Parse(Console.ReadLine());
            turnCounter = 1;
            unvisitedCells = size * size;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var cell = new Cell(row, col);

                    chessBoard.Add(cell);
                }
            }

            var currentCell = chessBoard[0];

            while (unvisitedCells > 0)
            {
                currentCell.TurnVisited = turnCounter++;
                currentCell.IsVisited = true;
                unvisitedCells--;

                currentCell = FindNextCell(currentCell);
            }
            
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var cell = chessBoard.First(c => c.Row == row && c.Column == col);
                    var currentCellResult = cell.TurnVisited.ToString().PadLeft(3);
                    Console.Write(currentCellResult + " ");
                }
                Console.WriteLine();
            }
        }

        private static Cell FindNextCell(Cell currentCell)
        {
            var nextMove = GetPossibleMoves(currentCell)
                .OrderBy(c => GetPossibleMoves(c).Count)
                .FirstOrDefault();

            return nextMove;
        }

        private static List<Cell> GetPossibleMoves(Cell currentCell)
        {
            var rightDown = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row + 1 && c.Column == currentCell.Column + 2);
            var rightTop = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row - 1 && c.Column == currentCell.Column + 2);
            var leftDown = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row + 1 && c.Column == currentCell.Column - 2);
            var leftTop = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row - 1 && c.Column == currentCell.Column - 2);

            var downRight = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row + 2 && c.Column == currentCell.Column + 1);
            var downLeft = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row + 2 && c.Column == currentCell.Column - 1);
            var topRight = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row - 2 && c.Column == currentCell.Column + 1);
            var topLeft = chessBoard.FirstOrDefault(c => c.Row == currentCell.Row - 2 && c.Column == currentCell.Column - 1);


            var resultSet = new List<Cell>
            {
                // The cells must be ordered in the exact order below:
                rightDown, rightTop, leftDown, leftTop, downRight, downLeft, topRight, topLeft
            }
            .Where(c => c != null && !c.IsVisited)
            .ToList();

            return resultSet;
        }
    }
}
