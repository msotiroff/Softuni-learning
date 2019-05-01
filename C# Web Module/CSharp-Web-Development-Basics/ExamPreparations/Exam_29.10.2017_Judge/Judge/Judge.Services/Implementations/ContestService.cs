namespace Judge.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Judge.Models;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ContestService : EntityValidationService, IContestService
    {
        private readonly JudgeDbContext db;

        public ContestService(JudgeDbContext db)
        {
            this.db = db;
        }

        public bool Add(string name, int userId)
        {
            var contest = new Contest
            {
                Name = name,
                UserId = userId
            };

            if (!this.ValidateModelState(contest))
            {
                return false;
            }

            this.db.Contests.Add(contest);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<ContestListServiceModel> All()
        {
            var allContests = this.db
                .Contests
                .ProjectTo<ContestListServiceModel>()
                .ToArray();

            return allContests;
        }

        public bool Delete(int id)
        {
            var contest = this.db.Contests.Find(id);

            if (contest == null)
            {
                return false;
            }

            this.db.Contests.Remove(contest);
            this.db.SaveChanges();

            return true;
        }

        public ContestUpdateServiceModel Get(int id)
        {
            var contest = this.db.Contests.FirstOrDefault(c => c.Id == id);

            if (contest == null)
            {
                return null;
            }

            return Mapper.Map<ContestUpdateServiceModel>(contest);
        }

        public bool Update(int id, string name)
        {
            var contest = this.db.Contests.Find(id);

            if (contest == null)
            {
                return false;
            }

            contest.Name = name;

            if (!this.ValidateModelState(contest))
            {
                return false;
            }

            this.db.Contests.Update(contest);
            this.db.SaveChanges();

            return true;
        }
    }
}
