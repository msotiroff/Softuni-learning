namespace Forum.App.Models.Commands
{
    using Contracts;
    using Forum.App.Menus;

    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        ICommandFactory commandFactory;

        public PostCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var userId = this.session.UserId;

            var postTitle = args[0];
            var postCategory = args[1];
            var postContent = args[2];

            var postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();

            var command = this.commandFactory.CreateCommand(nameof(ViewPostMenu));

            var menu = command.Execute(postId.ToString());

            return menu;
        }
    }
}
