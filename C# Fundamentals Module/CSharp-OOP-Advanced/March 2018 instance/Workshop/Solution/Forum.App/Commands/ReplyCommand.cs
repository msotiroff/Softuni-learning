namespace Forum.App.Models.Commands
{
    using Contracts;
    using Forum.App.Menus;

    public class ReplyCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        ICommandFactory commandFactory;

        public ReplyCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var authorId = this.session.UserId;

            var postId = int.Parse(args[0]);
            var content = args[1];

            this.postService.AddReplyToPost(postId, content, authorId);

            this.session.Back();

            var command = this.commandFactory.CreateCommand(nameof(ViewPostMenu));

            var menu = command.Execute(postId.ToString());

            return menu;
        }
    }
}
