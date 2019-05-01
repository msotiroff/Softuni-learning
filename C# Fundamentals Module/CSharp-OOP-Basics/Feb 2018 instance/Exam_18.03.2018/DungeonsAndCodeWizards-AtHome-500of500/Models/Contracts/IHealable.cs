namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Implementations.Characters;
    
    public interface IHealable
    {
        void Heal(Character character);
    }
}
