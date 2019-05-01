namespace Library.Web.Models.Director
{
    using Library.Web.Models.Interfaces;

    public class DirectorViewModel : IOriginator
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
