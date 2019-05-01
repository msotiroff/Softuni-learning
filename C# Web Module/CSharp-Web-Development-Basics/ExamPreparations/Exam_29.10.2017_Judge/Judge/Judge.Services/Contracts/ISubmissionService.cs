namespace Judge.Services.Contracts
{
    using Judge.Services.Models;
    using System.Collections.Generic;

    public interface ISubmissionService
    {
        bool Add(string executableCode, int contestId, int userId, bool compiled);

        IEnumerable<SubmissionListServiceModel> AllByUserId(int userId);
    }
}
