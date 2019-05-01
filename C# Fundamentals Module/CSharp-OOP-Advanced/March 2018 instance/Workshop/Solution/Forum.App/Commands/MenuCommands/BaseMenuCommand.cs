namespace Forum.App.Models.Commands
{
    using Contracts;
    using Common;

    public abstract class BaseMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public BaseMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public virtual IMenu Execute(params string[] args)
        {
            var menuName = this.GetType().Name.Replace(Constants.CommandSuffix, string.Empty);

            var menu = this.menuFactory.CreateMenu(menuName);

            return menu;
        }
    }
}
