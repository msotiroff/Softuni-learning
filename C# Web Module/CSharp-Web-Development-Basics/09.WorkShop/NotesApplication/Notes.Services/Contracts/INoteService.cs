namespace Notes.Services.Contracts
{
    public interface INoteService
    {
        bool Create(string title, string content, int userId);
    }
}
