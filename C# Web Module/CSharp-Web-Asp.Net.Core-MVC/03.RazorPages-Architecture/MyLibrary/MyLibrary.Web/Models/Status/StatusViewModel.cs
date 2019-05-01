namespace MyLibrary.Web.Models.Status
{
    public class StatusViewModel
    {
        public int Id { get; set; }
        
        public string BookTitle { get; set; }
        
        public string BorrowerName { get; set; }

        public string BorrowerAddress { get; set; }

        public string DateBorrowed { get; set; }

        public string ExpirationDate { get; set; }

        public string DateReturned { get; set; }
    }
}
