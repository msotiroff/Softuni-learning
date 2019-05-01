using SimpleMvc.Framework.Interfaces;
using System.IO;

namespace Notes.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../../ViewFiles/Home/Index.html");
        }
    }
}
