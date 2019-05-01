namespace Library.Web.Models.Author
{
    using Library.Web.Models.Interfaces;

    public class AuthorViewModel : IOriginator
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
