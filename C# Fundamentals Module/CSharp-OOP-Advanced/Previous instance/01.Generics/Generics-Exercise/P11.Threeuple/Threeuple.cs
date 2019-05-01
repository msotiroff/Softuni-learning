public class Threeuple<TFirst, TSecond, TThird>
{
    public TFirst First { get; private set; }

    public TSecond Second { get; private set; }

    public TThird Third { get; private set; }

    public Threeuple(TFirst first, TSecond second, TThird third)
    {
        this.First = first;
        this.Second = second;
        this.Third = third;
    }

    public override string ToString()
    {
        return $"{this.First} -> {this.Second} -> {this.Third}";
    }
}