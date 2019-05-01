namespace Forum.App.Models.Commands
{
    using Contracts;

    public class SignUpMenuCommand : BaseMenuCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
