namespace _05.StorageBox
{
    using System;
    using System.Text;

    public class Box<T>
    {
        private T[] data;
        private int count;

        public Box()
        {
            this.data = new T[4];
            this.Count = 0;
        }

        public int Count
        {
            get { return this.count; }
            private set
            {
                if (value > data.Length)
                {
                    throw new IndexOutOfRangeException("Collection is full.");
                }

                this.count = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == data.Length)
            {
                T[] oldData = data;
                data = new T[this.Count * 2];
                oldData.CopyTo(data, 0);
            }

            this.data[this.Count] = item;
            this.Count++;
        }

        public T Remove()
        {
            int lastIndex = this.Count - 1;
            T item = data[lastIndex];
            data[lastIndex] = default(T);
            this.Count--;
            return item;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.Append(this.data[i].ToString());
                if (i < this.Count - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }
    }
}