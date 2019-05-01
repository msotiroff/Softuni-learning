namespace SoftUniClone.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PagesViewModel<TModel>
    {
        [Display(Name = "Search")]
        public string SearchToken { get; set; }

        public IEnumerable<TModel> Elements { get; set; }

        public PaginationViewModel Pagination { get; set; }
    }
}