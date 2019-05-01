public class ExpressSoftware : Software
{
    public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption) 
        : base(name, capacityConsumption, memoryConsumption)
    {
    }

    public override int MemoryConsumption
    {
        get => base.MemoryConsumption;

        protected set => base.MemoryConsumption = value * 2;
    }
}
