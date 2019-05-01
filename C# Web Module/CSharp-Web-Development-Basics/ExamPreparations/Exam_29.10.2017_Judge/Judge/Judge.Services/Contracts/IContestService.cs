namespace Judge.Services.Contracts
{
    using Judge.Services.Models;
    using System.Collections.Generic;

    public interface IContestService
    {
        IEnumerable<ContestListServiceModel> All();

        bool Add(string name, int userId);

        ContestUpdateServiceModel Get(int id);

        bool Update(int id, string name);

        bool Delete(int id);
    }
}
