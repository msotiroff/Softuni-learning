namespace WizMail.Services.Contracts
{
    public interface IHashService
    {
        string ComputeHash(string text);
    }
}
