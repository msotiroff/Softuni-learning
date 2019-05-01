namespace P09.CollectionHierarchy.Contracts
{
    public interface IMyList : IRemovableCollection
    {
        int Used { get; }
    }
}
