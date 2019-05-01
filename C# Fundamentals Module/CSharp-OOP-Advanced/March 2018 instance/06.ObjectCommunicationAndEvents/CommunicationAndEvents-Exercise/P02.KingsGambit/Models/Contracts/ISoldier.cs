namespace P02.KingsGambit.Models.Contracts
{
    using System;

    public interface ISoldier
    {
        void OnKingBeingAttacked(object source, EventArgs args);
    }
}
