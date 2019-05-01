using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tyre[] tyres;

    public Car(string model, Engine engine, Cargo cargo, Tyre[] tyres)
    {
        this.Model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tyres = tyres;
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            this.model = value;
        }
    }

    public Engine Engine { get => engine;}

    public Cargo Cargo { get => cargo;}

    public Tyre[] Tyres { get => tyres;}

    public override string ToString()
    {
        string result = this.model + Environment.NewLine;

        return result;
    }
}
