using Notes.Models;
using System.Collections.Generic;

namespace Notes.Services.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
