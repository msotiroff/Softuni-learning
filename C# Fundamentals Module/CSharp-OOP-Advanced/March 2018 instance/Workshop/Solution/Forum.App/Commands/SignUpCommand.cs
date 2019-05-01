namespace Forum.App.Models.Commands
{
    using Contracts;
    using Forum.App.Common;
    using System;
    using Menus;

    public class SignUpCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            var isSuccessfull = this.userService.TrySignUpUser(username, password);

            if (!isSuccessfull)
            {
                throw new InvalidOperationException(Constants.InvalidLogin);
            }

            var view = this.menuFactory.CreateMenu(nameof(MainMenu));

            return view;
        }
    }
}
