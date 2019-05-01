namespace P10.TheHeiganDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheHeiganDance
    {
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;

        public static void Main(string[] args)
        {
            // Heigan's chamber is char matrix 15x15
            var chamber = new char[15][];
            FillChamber(chamber);

            Point playerPosition = new Point(7, 7);
            var player = new Player(18500, playerPosition);

            var heigansHealth = 3_000_000d;
            
            var canEscape = false;

            var damageOverHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                var inputParams = Console.ReadLine().Split(' ');

                var spell = inputParams[0];
                var attackedRow = int.Parse(inputParams[1]);
                var attackedColumn = int.Parse(inputParams[2]);

                var attackedPoint = new Point(attackedRow, attackedColumn);
                FillChamber(chamber);
                MarkDamagedArea(chamber, attackedPoint);

                heigansHealth -= damageOverHeigan;

                if (player.HasCloud)
                {
                    player.Health -= CloudDamage;
                    player.HasCloud = false;
                }

                if (player.Health <= 0)
                {
                    break;
                }

                if (heigansHealth <= 0)
                {
                    break;
                }
                
                if (chamber[player.Position.Row][player.Position.Column] == '*') // Damaged cells are marked with '*'
                {
                    canEscape = MovePlayer(player, chamber, attackedPoint);

                    if (!canEscape)
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                player.Health -= CloudDamage;
                                player.LastSpell = "Plague Cloud";
                                player.HasCloud = true;
                                break;
                            case "Eruption":
                                player.Health -= EruptionDamage;
                                player.LastSpell = "Eruption";
                                player.HasCloud = false;
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (player.Health <= 0)
                {
                    break;
                }
            }

            PrintOutput(player, heigansHealth);
        }

        private static void PrintOutput(Player player, double heigansHealth)
        {
            // Output:
            // First line:
            if (heigansHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heigansHealth:f2}");
            }

            // Second line:
            if (player.Health <= 0)
            {
                Console.WriteLine($"Player: Killed by {player.LastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {player.Health}");
            }

            // Third line:
            Console.WriteLine($"Final position: {player.Position.Row}, {player.Position.Column}");
        }

        private static bool MovePlayer(Player player, char[][] chamber, Point attackedPoint)
        {
            var isEscaped = false;

            var upperPosition = new Point(player.Position.Row - 1, player.Position.Column);
            var rightPosition = new Point(player.Position.Row, player.Position.Column + 1);
            var downPosition = new Point(player.Position.Row + 1, player.Position.Column);
            var leftPosition = new Point(player.Position.Row, player.Position.Column - 1);

            if (IsInChamber(upperPosition.Row, upperPosition.Column) && chamber[upperPosition.Row][upperPosition.Column] != '*')
            {
                isEscaped = true;
                player.Position = upperPosition;
            }
            else if (IsInChamber(rightPosition.Row, rightPosition.Column) && chamber[rightPosition.Row][rightPosition.Column] != '*')
            {
                isEscaped = true;
                player.Position = rightPosition;
            }
            else if (IsInChamber(downPosition.Row, downPosition.Column) && chamber[downPosition.Row][downPosition.Column] != '*')
            {
                isEscaped = true;
                player.Position = downPosition;
            }
            else if (IsInChamber(leftPosition.Row, leftPosition.Column) && chamber[leftPosition.Row][leftPosition.Column] != '*')
            {
                isEscaped = true;
                player.Position = leftPosition;
            }

            return isEscaped;
        }

        private static void MarkDamagedArea(char[][] chamber, Point attackedPoint)
        {
            var startRow = attackedPoint.Row - 1;
            var endRow = attackedPoint.Row + 1;
            var startColumn = attackedPoint.Column - 1;
            var endColumn = attackedPoint.Column + 1;

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startColumn; col <= endColumn; col++)
                {
                    if (IsInChamber(row, col))
                    {
                        chamber[row][col] = '*';
                    }
                }
            }
        }

        private static bool IsInChamber(int row, int column)
        {
            var result = row >= 0 && column >= 0
                && row < 15 && column < 15;

            return result;
        }

        private static void FillChamber(char[][] chamber)
        {
            for (int i = 0; i < chamber.Length; i++)
            {
                chamber[i] = new char[15];

                for (int j = 0; j < 15; j++)
                {
                    chamber[i][j] = '0'; // Free cells are marked with '0'
                }
            }
        }
    }
}
