namespace Library.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<BookAuthor>();
            this.Statuses = new HashSet<BookStatus>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Url]
        public string CoverImageUrl { get; set; }

        public bool IsBorrowed { get; set; }
        
        public IEnumerable<BookAuthor> Authors { get; set; }

        public IEnumerable<BookStatus> Statuses { get; set; }
    }
}
