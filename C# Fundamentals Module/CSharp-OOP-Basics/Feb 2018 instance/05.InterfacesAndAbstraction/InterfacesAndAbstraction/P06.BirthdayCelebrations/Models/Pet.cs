public class Pet : IBornable
{
    public string Name { get; private set; }

    public string Birthdate { get; private set; }

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
}
