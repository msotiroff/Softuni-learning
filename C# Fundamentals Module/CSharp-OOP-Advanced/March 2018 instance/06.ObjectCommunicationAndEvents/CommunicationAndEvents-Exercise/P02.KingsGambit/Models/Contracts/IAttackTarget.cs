namespace P02.KingsGambit.Models.Contracts
{
    using System;

    public interface IAttackTarget
    {
        void TakeAttack();

        event EventHandler BeingAttacked;
    }
}
