namespace ByTheCake.Services.Implementations
{
    using Data;

    public abstract class DataAccessService
    {
        protected readonly ByTheCakeDbContext db;

        protected DataAccessService()
        {
            this.db = new ByTheCakeDbContext();
        }
    }
}
