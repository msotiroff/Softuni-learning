namespace Library.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookStatus
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }

        [Required]
        public DateTime DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
