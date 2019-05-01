public class Dog : Animal
{
    public Dog(string name, int age, int learnedCommands) 
        : base(name, age)
    {
        this.LearnedCommands = learnedCommands;
    }

    public int LearnedCommands { get; private set; }
}
