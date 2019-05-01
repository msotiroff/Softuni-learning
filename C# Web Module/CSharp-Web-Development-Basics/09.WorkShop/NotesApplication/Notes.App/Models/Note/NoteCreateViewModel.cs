namespace Notes.App.Models.Note
{
    using System.ComponentModel.DataAnnotations;

    public class NoteCreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
