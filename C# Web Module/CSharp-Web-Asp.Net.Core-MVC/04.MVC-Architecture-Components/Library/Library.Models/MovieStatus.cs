namespace Library.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MovieStatus
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }

        [Required]
        public DateTime DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
