namespace P01_RawData.Models
{
    public class Car
    {
        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public Tyre[] Tyres { get; private set; }

        public Car(string model, Engine engine, Cargo cargo, params Tyre[] tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }
    }

}
