namespace Forum.App.Models.Commands
{
    using Contracts;

    public class ViewPostMenuCommand : BaseMenuCommand
    {
        public ViewPostMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }

        public override IMenu Execute(params string[] args)
        {
            var postId = int.Parse(args[0]);

            var menu = (IIdHoldingMenu)base.Execute(args);

            menu.SetId(postId);

            return menu;
        }
    }
}
