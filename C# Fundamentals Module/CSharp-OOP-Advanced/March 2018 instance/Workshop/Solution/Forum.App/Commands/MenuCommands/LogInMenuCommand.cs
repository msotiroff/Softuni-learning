namespace Forum.App.Models.Commands
{
    using Contracts;

    public class LogInMenuCommand : BaseMenuCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
