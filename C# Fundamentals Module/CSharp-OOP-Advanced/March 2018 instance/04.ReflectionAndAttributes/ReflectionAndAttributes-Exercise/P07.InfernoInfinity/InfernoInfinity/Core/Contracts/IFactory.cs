namespace InfernoInfinity.Core.Contracts
{
    public interface IFactory<T>
    {
        T CreateInstance(params string[] parameters);
    }
}
