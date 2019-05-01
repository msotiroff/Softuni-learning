namespace ModPanel.Services.Models.Post
{
    using ModPanel.Models;
    using ModPanel.Common.AutoMapping;
    using System;

    public class PostServiceModel : IMapWith<Post>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public string AuthorEmail { get; set; }
    }
}
