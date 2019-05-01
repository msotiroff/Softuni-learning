namespace Judge.Services.Models
{
    using AutoMapper;
    using Judge.Common.AutoMapping;
    using Judge.Models;
    using System.Collections.Generic;

    public class ContestListServiceModel : IMapWith<Contest>
    {
        public ContestListServiceModel()
        {
            this.Submissions = new HashSet<SubmissionListServiceModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int SubmissionsCount { get; set; }

        public int UserId { get; set; }

        public ICollection<SubmissionListServiceModel> Submissions { get; set; }
    }
}
