namespace P03.DependencyInversion.Strategies
{
	public class AdditionStrategy : ICalculatingStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
