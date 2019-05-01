namespace Judge.Services.Models
{
    using Judge.Common.AutoMapping;
    using Judge.Models;

    public class SubmissionListServiceModel : IMapWith<Submission>
    {
        public bool Compiled { get; set; }

        public int ContestId { get; set; }

        public string ContestName { get; set; }
    }
}
