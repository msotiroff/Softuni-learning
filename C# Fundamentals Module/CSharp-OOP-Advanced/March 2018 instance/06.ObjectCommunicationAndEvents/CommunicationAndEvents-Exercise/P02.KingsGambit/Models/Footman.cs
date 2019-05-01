namespace P02.KingsGambit.Models
{
    using Contracts;
    using System;

    public class Footman : BaseCitizen, ISoldier, INameableSoldier
    {
        public Footman(string name) 
            : base(name)
        {
        }

        public void OnKingBeingAttacked(object source, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
