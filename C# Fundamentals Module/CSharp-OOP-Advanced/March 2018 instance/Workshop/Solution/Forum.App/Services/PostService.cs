namespace Forum.App.Services
{
    using Common;
    using Contracts;
    using Forum.Data;
    using Forum.DataModels;
    using Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            var anyEmptyFields = string.IsNullOrWhiteSpace(postTitle)
                || string.IsNullOrWhiteSpace(postCategory)
                || string.IsNullOrWhiteSpace(postContent);

            if (anyEmptyFields)
            {
                throw new ArgumentException(Constants.EmptyFieldsErrorMsg);
            }

            var category = this.EnsureCategory(postCategory);

            var postId = this.forumData.Posts.Any()
                ? this.forumData.Posts.Max(p => p.Id) + 1
                : 1;

            var author = this.userService.GetUserById(userId);

            var post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            this.forumData.SaveChanges();

            return postId;
        }

        private Category EnsureCategory(string postCategory)
        {
            var category = this.forumData
                .Categories
                .FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                var categoryId = this.forumData.Categories.Any()
                    ? this.forumData.Categories.Max(c => c.Id) + 1
                    : 1;

                var newCategory = new Category(categoryId, postCategory, new List<int>());

                this.forumData.Categories.Add(newCategory);
                this.forumData.SaveChanges();

                return newCategory;
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            if (string.IsNullOrWhiteSpace(replyContents))
            {
                throw new ArgumentException(Constants.EmptyFieldsErrorMsg);
            }

            var post = this.GetPostById(postId);

            var replyId = this.forumData.Replies.Any()
                ? this.forumData.Replies.Max(r => r.Id) + 1
                : 1;

            var reply = new Reply(replyId, replyContents, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);

            this.forumData.SaveChanges();
        }

        private Post GetPostById(int postId)
        {
            var post = this.forumData
                .Posts
                .FirstOrDefault(p => p.Id == postId);

            //TODO: Throw if null...

            return post;
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            var categories = this.forumData
                .Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            var errorMsg = $"Category with id {categoryId} not found!";

            var category = this.forumData
                .Categories
                .FirstOrDefault(c => c.Id == categoryId)
                ?? throw new ArgumentException(errorMsg);

            return category.Name;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            var posts = this.forumData
                .Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData
                .Posts
                .FirstOrDefault(p => p.Id == postId);

            var title = post.Title;
            var author = this.userService.GetUserName(post.AuthorId);
            var content = post.Content;
            var replies = this.GetPostReplies(postId);

            var postViewModel = new PostViewModel(title, author, content, replies);

            return postViewModel;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            var replies = this.forumData
                .Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }
    }
}
