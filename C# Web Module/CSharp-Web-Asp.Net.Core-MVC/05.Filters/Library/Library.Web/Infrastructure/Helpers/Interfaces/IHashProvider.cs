namespace Library.Web.Infrastructure.Helpers.Interfaces
{
    public interface IHashProvider
    {
        string ComputeHash(string text);
    }
}
