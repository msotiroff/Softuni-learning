namespace Notes.Services.Models.User
{
    using Notes.Common.AutoMapping;
    using Notes.Models;
    using Notes.Services.Models.Note;
    using System.Collections.Generic;

    public class UserListServiceModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public ICollection<NoteListSericeModel> Notes { get; set; }
    }
}
