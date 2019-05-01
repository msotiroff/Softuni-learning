public abstract class Software
{
    public Software(string name, int capacityConsumption, int memoryConsumption)
    {
        this.Name = name;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }

    public string Name { get; private set; }

    public virtual int CapacityConsumption { get; protected set; }

    public virtual int MemoryConsumption { get; protected set; }
}
