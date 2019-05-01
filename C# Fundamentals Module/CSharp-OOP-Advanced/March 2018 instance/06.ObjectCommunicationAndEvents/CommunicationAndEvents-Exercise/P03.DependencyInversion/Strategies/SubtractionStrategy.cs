namespace P03.DependencyInversion.Strategies
{
	public class SubtractionStrategy : ICalculatingStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
