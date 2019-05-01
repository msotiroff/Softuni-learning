namespace BashSoft.App.Repositories.Contracts
{
    public interface IFilteredTaker
    {
        void FilterAndTake(string courseName, string givenFilter, string studentsCount);
    }
}
