using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private bool isRunning;
        private DungeonMaster dungeonMaster;

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

                var inputLine = Console.ReadLine();

                if (string.IsNullOrEmpty(inputLine))
                {
                    this.isRunning = false;
                    result = $"Final stats:{Environment.NewLine}";
                    result += this.dungeonMaster.GetStats();
                    Console.WriteLine(result);
                    continue;
                }

                var inputArgs = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var commandName = inputArgs.First();

                var commandParams = inputArgs.Skip(1).ToArray();

                try
                {
                    result = this.ProcessCommand(commandName, commandParams);
                }
                catch (ArgumentException ae)
                {
                    result = $"Parameter Error: {ae.Message}";
                }
                catch (InvalidOperationException ioe)
                {
                    result = $"Invalid Operation: {ioe.Message}";
                }

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }

                if (this.dungeonMaster.IsGameOver())
                {
                    this.isRunning = false;
                    Console.WriteLine("Final stats:");
                    var finalStats = this.dungeonMaster.GetStats();
                    Console.WriteLine(finalStats);
                }
            }
        }

        private string ProcessCommand(string commandName, string[] commandParams)
        {
            var result = string.Empty;

            switch (commandName)
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
                case "Attack":
                    result = this.dungeonMaster.Attack(commandParams);
                    break;
                case "Heal":
                    result = this.dungeonMaster.Heal(commandParams);
                    break;
                case "EndTurn":
                    result = this.dungeonMaster.EndTurn(commandParams);
                    break;
                case "GetStats":
                    result = this.dungeonMaster.GetStats();
                    break;
                case "IsGameOver":
                    result = this.dungeonMaster.IsGameOver().ToString();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
