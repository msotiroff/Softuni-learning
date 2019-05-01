namespace P10.ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
