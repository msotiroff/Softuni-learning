namespace P08.RawData
{
    public class Tyre
    {
        public int Age { get; set; }

        public double Pressure { get; set; }

        public Tyre (int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}