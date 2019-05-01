using System.Collections.Generic;

public abstract class Center
{
    public Center(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<Animal>();
    }

    public string Name { get; private set; }

    public List<Animal> StoredAnimals { get; private set; }
}