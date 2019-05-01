namespace InfernoInfinity.Data
{
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.Models.Contracts;
    using System.Collections.Generic;

    public class WeaponRepository : IRepository<IWeapon>
    {
        public WeaponRepository()
        {
            this.Data = new List<IWeapon>();
        }

        public IList<IWeapon> Data { get; private set; }

        public void Add(IWeapon weapon)
        {
            this.Data.Add(weapon);
        }
    }
}
