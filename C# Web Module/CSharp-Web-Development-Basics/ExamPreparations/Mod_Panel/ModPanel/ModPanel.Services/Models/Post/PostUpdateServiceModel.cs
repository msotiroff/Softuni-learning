namespace ModPanel.Services.Models.Post
{
    using ModPanel.Common.AutoMapping;
    using ModPanel.Models;

    public class PostUpdateServiceModel : IMapWith<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
