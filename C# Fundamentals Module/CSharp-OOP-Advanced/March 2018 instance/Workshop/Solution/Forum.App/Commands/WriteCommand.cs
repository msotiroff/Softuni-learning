using Forum.App.Contracts;

namespace Forum.App.Models.Commands
{
    public class WriteCommand : ICommand
    {
        private ISession session;

        public WriteCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var currentMenu = (ITextAreaMenu)this.session.CurrentMenu;
            currentMenu.TextArea.Write();

            return currentMenu;
        }
    }
}
