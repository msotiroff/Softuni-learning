namespace P02.KingsGambit.Models
{
    using Contracts;
    using System;

    public class King : BaseCitizen, IAttackTarget
    {
        public King(string name) 
            : base(name)
        {
        }

        public event EventHandler BeingAttacked;

        public void TakeAttack()
        {
            this.OnBeingAttacked();
        }

        private void OnBeingAttacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            this.BeingAttacked?.Invoke(this, EventArgs.Empty);
        }
    }
}
