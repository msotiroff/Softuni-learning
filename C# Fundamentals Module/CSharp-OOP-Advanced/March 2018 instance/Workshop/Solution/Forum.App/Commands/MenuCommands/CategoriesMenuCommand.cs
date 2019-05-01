namespace Forum.App.Models.Commands
{
    using Contracts;

    public class CategoriesMenuCommand : BaseMenuCommand
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
