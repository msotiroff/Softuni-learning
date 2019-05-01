namespace Library.Web.Models.Book
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BookBorrowingViewModel
    {
        [Required]
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }
        
        [Required]
        [Display(Name = "Borrower")]
        public string SelectedBorrowerId { get; set; }
        
        [Required(ErrorMessage = "Date of borrowing is required!")]
        [Display(Name = "Date of borrowing")]
        public DateTime DateBorrowed { get; set; }
        
        public DateTime? ExpirationDate { get; set; }
    }
}
