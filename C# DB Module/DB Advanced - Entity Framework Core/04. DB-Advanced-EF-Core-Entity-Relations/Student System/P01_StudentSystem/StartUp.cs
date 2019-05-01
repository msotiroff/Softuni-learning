namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    using P01_StudentSystemDbInitializer;

    public class StartUp
    {
        static void Main(string[] args)
        {
            DatabaseInitializer.ResetDatabase();

            //using (var db = new StudentSystemContext())
            //{
            //    DatabaseInitializer.InitialSeed(db);
            //}
        }
    }
}
