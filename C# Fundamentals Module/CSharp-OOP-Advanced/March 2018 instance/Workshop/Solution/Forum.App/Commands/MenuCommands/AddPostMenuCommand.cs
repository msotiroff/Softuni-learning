namespace Forum.App.Models.Commands
{
    using Contracts;

    public class AddPostMenuCommand : BaseMenuCommand
    {
        public AddPostMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
