namespace SoftUniClone.Services.Contracts
{
    public interface IPdfGenerator
    {
        byte[] GeneratePdfFromHtl(string html);
    }
}