using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models.Borrower
{
    public class BorrowerCreateViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
