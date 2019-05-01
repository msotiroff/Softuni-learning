using System.Collections.Generic;

namespace SimpleMvc.Framework.Models
{
    public class Model
    {
        public Model()
        {
            this.Data = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Data { get; }

        public string this[string key]
        {
            get => this.Data[key];
            set => this.Data[key] = value;
        }
    }
}
