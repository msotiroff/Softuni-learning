using System.Collections.Generic;

public class Garage
{
    public IList<Car> ParkedCars { get; private set; } = new List<Car>();

    public void Park(Car car)
    {
        this.ParkedCars.Add(car);
    }

    public void Unpark(Car car)
    {
        this.ParkedCars.Remove(car);
    }
}
