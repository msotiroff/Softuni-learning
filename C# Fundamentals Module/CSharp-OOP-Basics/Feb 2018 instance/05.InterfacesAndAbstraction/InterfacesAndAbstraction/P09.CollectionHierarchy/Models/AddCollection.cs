namespace P09.CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class AddCollection : IAddableCollection
    {
        protected IList<string> data = new List<string>();

        public virtual int Add(string item)
        {
            this.data.Add(item);

            return this.data.Count - 1;
        }
    }
}
