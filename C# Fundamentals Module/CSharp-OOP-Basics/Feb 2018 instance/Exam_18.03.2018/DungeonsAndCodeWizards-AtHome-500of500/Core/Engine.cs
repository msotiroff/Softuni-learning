using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        private bool isRunning;

        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var result = string.Empty;

                string inputLine = Console.ReadLine();

                if (string.IsNullOrEmpty(inputLine))
                {
                    this.isRunning = false;
                    result = $"Final stats:{Environment.NewLine}";
                    result += this.dungeonMaster.GetStats();
                    Console.WriteLine(result);
                    continue;
                }

                var commandLine = inputLine.Split();

                var mainCommand = commandLine.First();
                var commandParams = commandLine.Skip(1).ToArray();
                
                try
                {
                    switch (mainCommand)
                    {
                        case "JoinParty":
                            result = this.dungeonMaster.JoinParty(commandParams);
                            break;
                        case "AddItemToPool":
                            result = this.dungeonMaster.AddItemToPool(commandParams);
                            break;
                        case "PickUpItem":
                            result = this.dungeonMaster.PickUpItem(commandParams);
                            break;
                        case "UseItem":
                            result = this.dungeonMaster.UseItem(commandParams);
                            break;
                        case "UseItemOn":
                            result = this.dungeonMaster.UseItemOn(commandParams);
                            break;
                        case "GiveCharacterItem":
                            result = this.dungeonMaster.GiveCharacterItem(commandParams);
                            break;
                        case "GetStats":
                            result = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = this.dungeonMaster.Attack(commandParams);
                            break;
                        case "Heal":
                            result = this.dungeonMaster.Heal(commandParams);
                            break;
                        case "EndTurn":
                            result = this.dungeonMaster.EndTurn(commandParams);
                            break;
                        case "IsGameOver":
                            var isGameOver = this.dungeonMaster.IsGameOver();
                            if (isGameOver)
                            {
                                this.isRunning = false;
                                result = $"Final stats:{Environment.NewLine}";
                                result += this.dungeonMaster.GetStats();
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    var exception = ex.GetBaseException();

                    if (exception.GetType() == typeof(ArgumentException))
                    {
                        result = "Parameter Error: " + exception.Message;
                    }
                    else if (exception.GetType() == typeof(InvalidOperationException))
                    {
                        result = "Invalid Operation: " + exception.Message;
                    }
                }

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }

                if (this.dungeonMaster.IsGameOver())
                {
                    this.isRunning = false;
                    result = $"Final stats:{Environment.NewLine}";
                    result += this.dungeonMaster.GetStats();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
