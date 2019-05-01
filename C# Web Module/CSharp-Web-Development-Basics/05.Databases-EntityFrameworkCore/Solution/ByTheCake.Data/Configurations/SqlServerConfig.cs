namespace ByTheCake.Data.Configurations
{
    public class SqlServerConfig
    {
        internal const string ConnectionString = @"Server=DESKTOP-LRMHUDK\SQLEXPRESS;Database=ByTheCakeDb;Integrated Security = True;";

        internal const string AlternativeConnectionString = @"Server=.;Database=ByTheCakeDbExample;Integrated Security = True;";
    }
}
