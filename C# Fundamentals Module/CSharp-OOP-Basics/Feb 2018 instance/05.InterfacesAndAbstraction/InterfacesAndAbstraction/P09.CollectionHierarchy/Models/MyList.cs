namespace P09.CollectionHierarchy.Models
{
    using Contracts;

    public class MyList : AddRemoveCollection, IAddableCollection, IRemovableCollection, IMyList
    {
        public int Used => base.data.Count;

        public override string Remove()
        {
            var firstElement = base.data[0];
            base.data.RemoveAt(0);

            return firstElement;
        }
    }
}
