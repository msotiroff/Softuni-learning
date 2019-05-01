namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new FootballBettingContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
