namespace Library.Web.Models.Search
{
    using Library.Web.Infrastructure.Collections;
    using Library.Web.Models.Interfaces;

    public class SearchResultViewModel
    {
        public string SearchTerm { get; set; }

        public PaginatedList<ILibraryEntry> Entries { get; set; }
    }
}
