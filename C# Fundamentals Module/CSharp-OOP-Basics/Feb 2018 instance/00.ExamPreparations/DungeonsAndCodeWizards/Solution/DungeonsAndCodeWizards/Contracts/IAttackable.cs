using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
