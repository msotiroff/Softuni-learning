namespace Library.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Borrower
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<BookStatus> BorrowedBooks { get; set; }

        public ICollection<MovieStatus> BorrowedMovies { get; set; }
    }
}
