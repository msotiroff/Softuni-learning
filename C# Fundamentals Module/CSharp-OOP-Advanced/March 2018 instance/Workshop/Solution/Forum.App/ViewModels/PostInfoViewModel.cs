namespace Forum.App.Models.ViewModels
{
    using Contracts;

    public class PostInfoViewModel : IPostInfoViewModel
    {
        public PostInfoViewModel(int id, string title, int repliesCount)
        {
            this.Id = id;
            this.Title = title;
            this.ReplyCount = repliesCount;
        }

        public int Id { get; }

        public string Title { get; }

        public int ReplyCount { get; }
    }
}
