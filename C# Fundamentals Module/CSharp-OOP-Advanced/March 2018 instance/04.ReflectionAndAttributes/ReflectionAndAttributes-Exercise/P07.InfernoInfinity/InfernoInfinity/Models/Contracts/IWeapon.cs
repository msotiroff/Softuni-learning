namespace InfernoInfinity.Models.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        IGem[] Sockets { get; }

        void AddGem(IGem gem, int index);
        void RemoveGem(int index);
    }
}
