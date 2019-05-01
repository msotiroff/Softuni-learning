namespace Forum.App.Models.Commands
{
    using Contracts;
    using Forum.App.Menus;

    public class LogOutCommand : ICommand
    {
        ISession session;
        IMenuFactory menuFactory;

        public LogOutCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            this.session.Reset();

            var view = this.menuFactory.CreateMenu(nameof(MainMenu));

            return view;
        }
    }
}
