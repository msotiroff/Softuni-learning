namespace Notes.Services.Models.Note
{
    using Notes.Common.AutoMapping;
    using Notes.Models;

    public class NoteListSericeModel : IMapWith<Note>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
