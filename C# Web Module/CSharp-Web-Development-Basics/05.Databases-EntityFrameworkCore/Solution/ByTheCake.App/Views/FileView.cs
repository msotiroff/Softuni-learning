namespace ByTheCake.App.Views
{
    using HTTPServer.Contracts;

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
