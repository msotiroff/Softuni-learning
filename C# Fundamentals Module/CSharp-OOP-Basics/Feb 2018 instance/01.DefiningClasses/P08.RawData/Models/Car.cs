namespace P08.RawData
{
    using System.Collections.Generic;
    using System.Linq;

    class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo{ get; set; }

        public IEnumerable<Tyre> Tyres { get; set; }

        public Car (string model, Engine engine, Cargo cargo, params Tyre[] tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres.ToList();
        }
    }
}
