public interface IWareHouse
{
    void AddAmmunitions(string name, int count);
    bool TryToEquipSoldier(ISoldier soldier);
    void EquipArmy(IArmy army);
}
