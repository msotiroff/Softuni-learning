namespace ModPanel.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using ModPanel.Data;
    using ModPanel.Models;
    using ModPanel.Services.Models.Post;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostService : DataAccessService, IPostService
    {
        public PostService(ModPanelDbContext db) 
            : base(db)
        {
        }

        public IEnumerable<PostServiceModel> All()
        {
            return this.db
                .Posts
                .ProjectTo<PostServiceModel>()
                .OrderByDescending(p => p.CreatedOn)
                .ToArray();
        }

        public bool Create(string title, string content, int authorId)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                CreatedOn = DateTime.UtcNow,
                AuthorId = authorId
            };

            if (!this.ValidateModelState(post))
            {
                return false;
            }

            this.db.Posts.Add(post);
            this.db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var post = this.db.Posts.Find(id);
            if (post == null)
            {
                return false;
            }

            this.db.Posts.Remove(post);
            this.db.SaveChanges();

            return true;
        }

        public PostUpdateServiceModel GetById(int id)
        {
            var post = this.db.Posts.Find(id);

            return post != null ? Mapper.Map<PostUpdateServiceModel>(post) : null;
        }

        public bool Update(int id, string title, string content)
        {
            var post = this.db.Posts.Find(id);
            if (post == null)
            {
                return false;
            }

            post.Title = title;
            post.Content = content;

            this.db.Posts.Update(post);
            this.db.SaveChanges();

            return true;
        }
    }
}
