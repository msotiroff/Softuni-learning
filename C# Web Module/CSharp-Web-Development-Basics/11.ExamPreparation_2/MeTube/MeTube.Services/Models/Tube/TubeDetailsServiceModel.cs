namespace MeTube.Services.Models.Tube
{
    using MeTube.Common.AutoMapping;
    using MeTube.Models;

    public class TubeDetailsServiceModel : IMapWith<Tube>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string YouTubeId { get; set; }

        public int Views { get; set; }
    }
}
