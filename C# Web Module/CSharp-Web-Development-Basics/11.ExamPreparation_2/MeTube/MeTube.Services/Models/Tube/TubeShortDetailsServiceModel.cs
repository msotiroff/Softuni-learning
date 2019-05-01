namespace MeTube.Services.Models.Tube
{
    using MeTube.Common.AutoMapping;
    using MeTube.Models;

    public class TubeShortDetailsServiceModel : IMapWith<Tube>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Author { get; set; }
    }
}
