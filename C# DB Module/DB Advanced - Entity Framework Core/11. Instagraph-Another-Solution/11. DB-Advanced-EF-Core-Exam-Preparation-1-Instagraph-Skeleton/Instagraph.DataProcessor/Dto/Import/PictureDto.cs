namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    class PictureDto
    {
        [Required]
        public string Path { get; set; }

        [Required]
        public decimal? Size { get; set; }
    }
}
