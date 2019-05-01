using System;

public abstract class Tyre : ITyre
{
    private const double TyreStartDegradationValue = 100;
    protected double degradationMinValue = 0;
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = TyreStartDegradationValue;
    }

    public virtual string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double Hardness
    {
        get { return this.hardness; }
        protected set { this.hardness = value; }
    }

    public virtual double Degradation
    {
        get { return this.degradation; }

        protected set
        {
            if (value < degradationMinValue)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}