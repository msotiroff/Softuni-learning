using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) 
        : base(DataConstants.UltrasoftTyreDefaultName, hardness)
    {
        this.grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < DataConstants.UltraSoftTyreMinDegradation)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
            }

            base.Degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        base.ReduceDegradation();
        this.Degradation -= this.grip;
    }
}
