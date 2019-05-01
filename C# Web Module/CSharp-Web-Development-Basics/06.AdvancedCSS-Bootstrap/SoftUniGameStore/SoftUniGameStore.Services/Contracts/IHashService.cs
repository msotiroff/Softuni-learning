namespace SoftUniGameStore.Services.Contracts
{
    public interface IHashService : IService
    {
        string ComputeHash(string text);
    }
}
