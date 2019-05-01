namespace Notes.Repositories.Implementations
{
    using Contracts;
    using Generic;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(DbContext context) 
            : base(context)
        {
        }


    }
}
