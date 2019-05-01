public abstract class Bender : IBender
{
    private string name;
    private double power;

    public abstract double TotalPower { get; }

    protected Bender(string name, double power)
    {
        this.Name = name;
        this.Power = power;
    }

    public double Power
    {
        get => this.power;
        protected set
        {
            this.power = value;
        }
    }
    
    public string Name
    {
        get => this.name;
        private set
        {
            name = value;
        }
    }
}