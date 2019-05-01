using Notes.Data;
using Notes.Models;
using Notes.Services.Contracts;

namespace Notes.Services.Implementations
{
    public class NoteService : EntityValidationService, INoteService
    {
        private readonly NotesDbContext db;

        public NoteService(NotesDbContext db)
        {
            this.db = db;
        }

        public bool Create(string title, string content, int userId)
        {
            var note = new Note
            {
                Title = title,
                Content = content,
                UserId = userId
            };

            if (!this.ValidateModelState(note))
            {
                return false;
            }

            this.db.Notes.Add(note);
            this.db.SaveChanges();

            return true;
        }
    }
}
