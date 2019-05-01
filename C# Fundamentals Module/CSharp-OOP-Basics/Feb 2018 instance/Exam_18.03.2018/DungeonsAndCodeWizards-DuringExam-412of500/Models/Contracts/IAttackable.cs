namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Implementations.Characters;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}
