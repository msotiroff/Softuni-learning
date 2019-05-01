namespace P09.CollectionHierarchy.Models
{
    using Contracts;

    public class AddRemoveCollection : AddCollection, IAddableCollection, IRemovableCollection
    {
        public override int Add(string item)
        {
            this.data.Insert(0, item);

            return 0;
        }

        public virtual string Remove()
        {
            int lastIndex = this.data.Count - 1;
            var lastItem = this.data[lastIndex];
            this.data.RemoveAt(lastIndex);

            return lastItem;
        }
    }
}
