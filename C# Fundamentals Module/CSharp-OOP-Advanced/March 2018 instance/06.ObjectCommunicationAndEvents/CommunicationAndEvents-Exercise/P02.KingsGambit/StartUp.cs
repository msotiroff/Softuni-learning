namespace P02.KingsGambit
{
    using P02.KingsGambit.Models;
    using P02.KingsGambit.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            IList<INameableSoldier> soldiers = new List<INameableSoldier>();

            var kingName = Console.ReadLine();

            IAttackTarget king = new King(kingName);
            ReadSoldiers(king, soldiers);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandParams = command.Split();
                var mainCommand = commandParams[0];
                var name = commandParams[1];

                switch (mainCommand)
                {
                    case "Attack":
                        king.TakeAttack();
                        break;
                    case "Kill":
                        var killedSoldier = soldiers.FirstOrDefault(s => s.Name == name);
                        soldiers.Remove(killedSoldier);
                        king.BeingAttacked -= killedSoldier.OnKingBeingAttacked;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ReadSoldiers(IAttackTarget king, IList<INameableSoldier> soldiers)
        {
            ReadGuards(king, soldiers);
            ReadFootmans(king, soldiers);
        }

        private static void ReadFootmans(IAttackTarget king, IList<INameableSoldier> soldiers)
        {
            var footmansNames = Console.ReadLine().Split();

            foreach (var footmanName in footmansNames)
            {
                var footman = new Footman(footmanName);
                soldiers.Add(footman);
                king.BeingAttacked += footman.OnKingBeingAttacked;
            }
        }

        private static void ReadGuards(IAttackTarget king, IList<INameableSoldier> soldiers)
        {
            var guardsNames = Console.ReadLine().Split();

            foreach (var guardname in guardsNames)
            {
                var guard = new RoyalGuard(guardname);
                soldiers.Add(guard);
                king.BeingAttacked += guard.OnKingBeingAttacked;
            }
        }
    }
}
