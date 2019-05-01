using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tyre
{
    private double pressure;
    private int age;

    public Tyre(double pressure, int age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            this.age = value;
        }
    }


    public double Pressure
    {
        get { return this.pressure; }
        set
        {
            pressure = value;
        }
    }

}
