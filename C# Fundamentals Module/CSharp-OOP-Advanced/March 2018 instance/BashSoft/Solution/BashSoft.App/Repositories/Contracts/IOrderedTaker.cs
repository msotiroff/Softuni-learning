namespace BashSoft.App.Repositories.Contracts
{
    public interface IOrderedTaker
    {
        void OrderAndTake(string courseName, string comparison, string studentsCount);
    }
}
