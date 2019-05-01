using System;

public class TrafficLight
{
    public Signal Light { get; private set; }

    public TrafficLight(string light)
    {
        this.Light = this.ParseLight(light);
    }

    public void ChangeSignal()
    {
        switch (this.Light)
        {
            case Signal.Red:
                this.Light = Signal.Green;
                break;
            case Signal.Green:
                this.Light = Signal.Yellow;
                break;
            case Signal.Yellow:
                this.Light = Signal.Red;
                break;
            default:
                break;
        }
    }

    private Signal ParseLight(string light)
    {
        Signal signal;
        if (Enum.TryParse<Signal>(light, out signal))
        {
            return signal;
        }

        throw new ArgumentException();
    }

    public override string ToString()
    {
        return this.Light.ToString();
    }
}
