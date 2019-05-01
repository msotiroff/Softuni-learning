namespace Library.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<BookAuthor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<BookAuthor> Books { get; set; }
    }
}