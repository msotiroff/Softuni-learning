namespace MeTube.Services.Models.Tube
{
    using MeTube.Common.AutoMapping;
    using MeTube.Models;

    public class TubeListServiceModel : IMapWith<Tube>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string YouTubeId { get; set; }
        
        public string UploaderUsername { get; set; }
    }
}
