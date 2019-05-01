namespace Notes.App.Views.User
{
    using SimpleMvc.Framework.Interfaces;
    using System.IO;

    public class Register : IRenderable
    {
        public string Render()
        {
            var page = File.ReadAllText(@"..\..\..\ViewFiles\User\Register.html");

            return page;
        }
    }
}
