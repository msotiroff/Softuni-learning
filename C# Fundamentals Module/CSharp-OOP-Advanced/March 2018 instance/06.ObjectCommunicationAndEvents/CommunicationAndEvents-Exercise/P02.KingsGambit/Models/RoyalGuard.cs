namespace P02.KingsGambit.Models
{
    using Contracts;
    using System;

    public class RoyalGuard : BaseCitizen, ISoldier, INameableSoldier
    {
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        public void OnKingBeingAttacked(object source, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
