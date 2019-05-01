namespace ExtendedDataBase.Models
{
    public class Person
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; }

        public string Username { get; }
    }
}
