namespace P06.Animals.Contracts
{
    public interface ISoundProducable
    {
        string Name { get; }
        int Age { get; }
        string Gender { get; }

        string ProduceSound();
    }
}
