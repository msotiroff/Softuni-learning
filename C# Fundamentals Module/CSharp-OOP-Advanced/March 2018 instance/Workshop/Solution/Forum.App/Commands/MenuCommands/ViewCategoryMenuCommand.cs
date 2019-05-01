namespace Forum.App.Models.Commands
{
    using Contracts;

    public class ViewCategoryMenuCommand : BaseMenuCommand
    {
        public ViewCategoryMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }

        public override IMenu Execute(params string[] args)
        {
            var categoryId = int.Parse(args[0]);

            var menu = (IIdHoldingMenu)base.Execute(args);

            menu.SetId(categoryId);

            return menu;
        }
    }
}
