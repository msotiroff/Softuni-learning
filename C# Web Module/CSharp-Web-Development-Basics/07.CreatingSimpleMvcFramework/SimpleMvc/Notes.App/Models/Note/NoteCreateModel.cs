namespace Notes.App.Models.Note
{
    public class NoteCreateModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
