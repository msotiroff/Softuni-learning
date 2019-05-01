namespace P03.DependencyInversion.Strategies
{
    public interface ICalculatingStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
