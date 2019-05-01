namespace Judge.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Judge.Data;
    using Judge.Models;
    using Judge.Services.Contracts;
    using Judge.Services.Models;

    public class SubmissionService : EntityValidationService, ISubmissionService
    {
        private readonly JudgeDbContext db;

        public SubmissionService(JudgeDbContext db)
        {
            this.db = db;
        }

        public bool Add(string executableCode, int contestId, int userId, bool compiled)
        {
            var submission = new Submission
            {
                ExecutableCode = executableCode,
                ContestId = contestId,
                UserId = userId,
                Compiled = compiled
            };

            if (!this.ValidateModelState(submission))
            {
                return false;
            }

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<SubmissionListServiceModel> AllByUserId(int userId)
        {
            return this.db
                .Submissions
                .Where(s => s.UserId == userId)
                .ProjectTo<SubmissionListServiceModel>()
                .ToArray();
        }
    }
}
