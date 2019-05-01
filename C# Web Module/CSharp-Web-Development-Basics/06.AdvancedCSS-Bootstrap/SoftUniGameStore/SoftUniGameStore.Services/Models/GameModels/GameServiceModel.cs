using System;

namespace SoftUniGameStore.Services.Models
{
    public class GameServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public string Trailer { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
