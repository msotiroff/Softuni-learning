using System;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {
        var result = this.left.CompareTo(this.right);

        switch (result)
        {
            case -1:
                return this.right;
            case 1:
                return this.left;
            default:
                return default(T);
        }
    }
}
