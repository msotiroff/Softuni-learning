public class Cat : Animal
{
    public Cat(string name, int age, int intelligenceCoefficient) 
        : base(name, age)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient { get; private set; }
}
