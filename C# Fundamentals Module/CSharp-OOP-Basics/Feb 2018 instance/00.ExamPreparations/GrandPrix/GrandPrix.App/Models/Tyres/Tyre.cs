using System;

public abstract class Tyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = DataConstants.TyreInitialDegradation;
    }

    public string Name { get; private set; }

    public double Hardness { get; private set; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < DataConstants.AbstractTyreMinDegradation)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
            }

            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}
