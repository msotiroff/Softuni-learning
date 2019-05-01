namespace KittenShop.App.Models.Kitten
{
    using System.ComponentModel.DataAnnotations;

    public class KittenCreateViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Range(1, 20)]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }
    }
}
