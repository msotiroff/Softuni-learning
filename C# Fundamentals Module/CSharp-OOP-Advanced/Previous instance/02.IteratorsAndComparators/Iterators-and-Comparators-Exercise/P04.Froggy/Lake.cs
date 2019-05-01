using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
{
    private List<T> data;

    public Lake(params T[] elements)
    {
        this.data = new List<T>(elements);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < data.Count; i += 2)
        {
            yield return this.data[i];
        }

        var lastOddPosition = this.data.Count % 2 == 0
            ? this.data.Count - 1
            : this.data.Count - 2;

        for (int i = lastOddPosition; i >= 1; i -= 2)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
