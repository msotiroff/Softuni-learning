public class PetFactory
{
    public Pet CreateInstance(string name, int age, string kind)
    {
        var pet = new Pet(name, age, kind);

        return pet;
    }
}
