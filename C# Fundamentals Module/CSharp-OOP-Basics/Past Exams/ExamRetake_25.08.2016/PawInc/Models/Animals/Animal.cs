public abstract class Animal
{
    public Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public bool CleansingStatus { get; private set; }

    public void MarkAnimalAsCleaned()
    {
        this.CleansingStatus = true;
    }
}
