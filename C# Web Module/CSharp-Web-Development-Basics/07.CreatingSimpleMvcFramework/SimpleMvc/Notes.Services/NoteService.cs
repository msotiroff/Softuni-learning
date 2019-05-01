﻿using Notes.Data;
using Notes.Models;
using System.Linq;

namespace Notes.Services
{
    public class NoteService
    {
        private readonly NotesDbContext db;

        public NoteService()
        {
            this.db = new NotesDbContext();
        }

        public void Add(string title, string content, int userId)
        {
            var userExist = this.db.Users.Any(u => u.Id == userId);

            if (userExist)
            {
                var note = new Note
                {
                    Title = title,
                    Content = content,
                    UserId = userId
                };

                this.db.Notes.Add(note);
                this.db.SaveChanges();
            }
        }
    }
}
