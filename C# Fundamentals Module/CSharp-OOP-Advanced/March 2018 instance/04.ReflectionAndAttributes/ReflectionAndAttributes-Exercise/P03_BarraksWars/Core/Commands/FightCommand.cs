using _03BarracksFactory.Contracts;
using System;

namespace P03_BarraksWars.Core.Commands
{
    public class FightCommand : BaseCommand
    {
        public FightCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
