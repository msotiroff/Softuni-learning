namespace P01_RawData.Models
{
    public class Tyre
    {
        public double Pressure { get; private set; }

        public int Age { get; private set; }

        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}