namespace Forum.App.Models.Commands
{
    using Contracts;
    using Forum.App.Common;
    using Forum.App.Menus;
    using System;

    public class LogInCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            var isSuccessfull = this.userService.TryLogInUser(username, password);

            if (!isSuccessfull)
            {
                throw new InvalidOperationException(Constants.InvalidLogin);
            }

            var view = this.menuFactory.CreateMenu(nameof(MainMenu));

            return view;
        }
    }
}
