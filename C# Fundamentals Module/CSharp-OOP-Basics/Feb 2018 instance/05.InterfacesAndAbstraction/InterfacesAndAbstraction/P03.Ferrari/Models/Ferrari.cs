public class Ferrari : ICar
{
    private IDriver driver;

    public IDriver Driver
    {
        get => this.driver;
        private set => this.driver = value;
    }

    public string Model { get; private set; }

    public Ferrari(IDriver driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public string PushGasPedal()
    {
        return "Brakes!";
    }

    public string UseBrakes()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.PushGasPedal()}/{this.UseBrakes()}/{this.Driver.Name}";
    }
}
