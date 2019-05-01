namespace SoftUniClone.Web.Models
{
    using System;

    public class PaginationViewModel
    {
        public string ActionLink { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalElements { get; set; }

        public int PreviousPage
        {
            get
            {
                return this.CurrentPage <= 1
                    ? 1
                    : this.CurrentPage - 1;
            }
        }

        public int NextPage
        {
            get
            {
                return this.CurrentPage >= this.TotalPages
                    ? this.TotalPages
                    : this.CurrentPage + 1;
            }
        }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)this.TotalElements / this.PageSize);
            }
        }
    }
}