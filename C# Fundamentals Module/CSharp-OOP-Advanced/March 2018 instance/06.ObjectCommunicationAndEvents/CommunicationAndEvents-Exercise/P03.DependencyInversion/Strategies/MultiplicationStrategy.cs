namespace P03.DependencyInversion.Strategies
{
    public class MultiplicationStrategy : ICalculatingStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
