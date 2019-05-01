namespace MvcFramework.Security
{
    public class Authentication
    {
        internal Authentication()
        {
            this.IsAuthenticated = false;
        }

        internal Authentication(string name)
        {
            this.Name = name;
            this.IsAuthenticated = true;
        }

        public bool IsAuthenticated { get; }

        public string Name { get; }
    }
}
