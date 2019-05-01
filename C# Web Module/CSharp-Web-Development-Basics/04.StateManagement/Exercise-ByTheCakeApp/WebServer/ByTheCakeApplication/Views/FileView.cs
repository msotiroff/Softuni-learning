namespace HTTPServer.ByTheCakeApplication.Views
{
    using Server.Contracts;

    public class FileView : IView
    {
        private readonly string htmlFileContent;

        public FileView(string htmlFileContent)
        {
            this.htmlFileContent = htmlFileContent;
        }

        public string View() => this.htmlFileContent;
    }
}
