namespace Library.Web.Models.Movie
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MovieBorrowingViewModel
    {
        [Required]
        public int Id { get; set; }

        public string MovieTitle { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }

        [Required]
        [Display(Name = "Borrower")]
        public string SelectedBorrowerId { get; set; }

        [Required]
        [Display(Name = "Date of borrowing")]
        public DateTime DateBorrowed { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
