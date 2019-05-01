using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemType)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(Item)
                    && !t.IsAbstract)
                .FirstOrDefault(t => t.Name == itemType);

            if (type == null)
            {
                throw new ArgumentException($"Invalid item \"{itemType}\"!");
            }

            var item = (Item)Activator.CreateInstance(type);

            return item;
        }
    }
}
