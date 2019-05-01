namespace FDMC.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CatCreateViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public List<SelectListItem> Breeds { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public string BreedId { get; set; }

        [Required]
        [Range(0, 20)]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
