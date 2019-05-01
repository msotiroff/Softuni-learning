public interface ICar
{
    IDriver Driver { get; }

    string UseBrakes();

    string PushGasPedal();
}
