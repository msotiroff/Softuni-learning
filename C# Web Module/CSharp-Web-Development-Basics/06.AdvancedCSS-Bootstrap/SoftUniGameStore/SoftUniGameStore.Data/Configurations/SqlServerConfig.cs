namespace SoftUniGameStore.Data.Configurations
{
    public class SqlServerConfig
    {
        internal const string ConnectionString = @"Server=DESKTOP-LRMHUDK\SQLEXPRESS;Database=GameStoreDb;Integrated Security=True;";

        internal const string AlternativeConnectionString = @"Server=.\SQLEXPRESS;Database=GameStoreDb;Integrated Security=True;";
    }
}
