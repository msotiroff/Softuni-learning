namespace Forum.App.Factories
{
    using Forum.App.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MenuFactory : IMenuFactory
    {
        private const string MenuNotFoundErrorMsg = "Menu not found!";
        private const string NotAMenuErrorMsg = "{0} is not a menu!";

        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        
        public IMenu CreateMenu(string menuName)
        {
            var menuType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => !t.IsAbstract)
                .FirstOrDefault(t => t.Name == menuName)
                ?? throw new InvalidOperationException(MenuNotFoundErrorMsg);

            var isMenu = typeof(IMenu).IsAssignableFrom(menuType);

            if (!isMenu)
            {
                throw new InvalidOperationException(string.Format(NotAMenuErrorMsg, menuName));
            }

            var parameters = menuType
                .GetConstructors()
                .First()
                .GetParameters()
                .Select(p => this.serviceProvider.GetService(p.ParameterType))
                .ToArray();

            var menu = (IMenu)Activator.CreateInstance(menuType, parameters);

            return menu;
        }
    }
}
