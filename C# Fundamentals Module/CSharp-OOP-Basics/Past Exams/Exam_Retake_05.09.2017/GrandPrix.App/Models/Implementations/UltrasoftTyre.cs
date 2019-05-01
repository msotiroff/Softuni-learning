using System;

public class UltrasoftTyre : Tyre
{
    private const string InitialName = "Ultrasoft";

    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        base.degradationMinValue = 30;
        base.Name = InitialName;
        this.Grip = grip;
    }

    public double Grip
    {
        get => this.grip;

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            this.grip = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness + this.grip;
    }
}