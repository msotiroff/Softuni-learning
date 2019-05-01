namespace P03.DependencyInversion.Strategies
{
    using System;

    public class DivisionStrategy : ICalculatingStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            try
            {
                return firstOperand / secondOperand;
            }
            catch (DivideByZeroException)
            {
                return default(int);
            }
        }
    }
}
