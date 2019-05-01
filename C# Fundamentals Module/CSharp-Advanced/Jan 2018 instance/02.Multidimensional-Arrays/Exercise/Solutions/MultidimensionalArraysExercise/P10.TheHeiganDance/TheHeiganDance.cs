namespace P10.TheHeiganDance
{
    using System;
    using System.Linq;

    class TheHeiganDance
    {
        private static bool[,] chamber = new bool[15, 15];
        private static readonly int CloudDamage = 3500;
        private static readonly int EruptionDamage = 6000;
        private static int playerHealth = 18500;
        private static double heiganHealth = 3000000;

        static void Main(string[] args)
        {
            var playerPosition = new Cell(7, 7);

            var damageToHeigan = double.Parse(Console.ReadLine());

            string spell = string.Empty;

            var hasCloudSpell = false;

            while (true)
            {
                ClearDamagedCells();

                var inputParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                spell = inputParams[0];
                var targetRow = int.Parse(inputParams[1]);
                var targetCol = int.Parse(inputParams[2]);

                MarkDamagedCells(targetRow, targetCol);

                heiganHealth -= damageToHeigan;

                if (hasCloudSpell)
                {
                    playerHealth -= CloudDamage;
                    hasCloudSpell = false;
                }

                if (playerHealth <= 0)
                {
                    spell = "Cloud";
                    break;
                }

                if (heiganHealth <= 0)
                {
                    break;
                }
                
                if (chamber[playerPosition.Row, playerPosition.Column])
                {
                    var canEscape = MovePlayer(playerPosition);

                    if (!canEscape)
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerHealth -= CloudDamage;
                                hasCloudSpell = true;
                                break;
                            case "Eruption":
                                playerHealth -= EruptionDamage;
                                break;
                            default:
                                break;
                        }

                        if (playerHealth <= 0)
                        {
                            break;
                        }
                    }
                }
            }

            if (spell.Equals("Cloud"))
            {
                spell = "Plague Cloud";
            }

            Console.WriteLine(heiganHealth <= 0 ? "Heigan: Defeated!" : $"Heigan: {heiganHealth:f2}");
            Console.WriteLine(playerHealth <= 0 ? $"Player: Killed by {spell}" : $"Player: {playerHealth}");
            Console.WriteLine($"Final position: {playerPosition.Row}, {playerPosition.Column}");
        }

        private static bool MovePlayer(Cell playerPosition)
        {
            if (IsInChamber(playerPosition.Row - 1, playerPosition.Column))
            {
                if (!chamber[playerPosition.Row - 1, playerPosition.Column])
                {
                    playerPosition.Row -= 1;
                    return true;
                }
            }

            if (IsInChamber(playerPosition.Row, playerPosition.Column + 1))
            {
                if (!chamber[playerPosition.Row, playerPosition.Column + 1])
                {
                    playerPosition.Column += 1;
                    return true;
                }
            }

            if (IsInChamber(playerPosition.Row + 1, playerPosition.Column))
            {
                if (!chamber[playerPosition.Row + 1, playerPosition.Column])
                {
                    playerPosition.Row += 1;
                    return true;
                }
            }

            if (IsInChamber(playerPosition.Row, playerPosition.Column - 1))
            {
                if (!chamber[playerPosition.Row, playerPosition.Column - 1])
                {
                    playerPosition.Column -= 1;
                    return true;
                }
            }

            return false;
        }

        private static void ClearDamagedCells()
        {
            for (int row = 0; row < 15; row++)
            {
                for (int col = 0; col < 15; col++)
                {
                    chamber[row, col] = false;
                }
            }
        }

        private static void MarkDamagedCells(int targetRow, int targetCol)
        {
            for (int row = targetRow - 1; row <= targetRow + 1; row++)
            {
                for (int col = targetCol - 1; col <= targetCol + 1; col++)
                {
                    if (IsInChamber(row, col))
                    {
                        chamber[row, col] = true;
                    }
                }
            }
        }

        private static bool IsInChamber(int row, int col)
        {
            return row >= 0
                && row < 15
                && col >= 0
                && col < 15;
        }
    }

    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
