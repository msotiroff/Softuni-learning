namespace CustomHttpServer.Application.Models
{
    using System.Collections.Generic;

    public class UserModel
    {
        private readonly IDictionary<string, object> objects;

        public UserModel()
        {
            this.objects = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get { return this.objects[key]; }
            set { this.objects[key] = value; }
        }

        public void Add(string key, object value)
        {
            this.objects[key] = value;
        }
    }
}
