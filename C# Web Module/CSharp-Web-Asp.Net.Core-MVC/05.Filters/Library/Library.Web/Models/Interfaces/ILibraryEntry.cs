namespace Library.Web.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ILibraryEntry
    {
        int Id { get; set; }

        string Title { get; set; }

        string Status { get; set; }
        
        List<IOriginator> Originators { get; set; }
    }
}
