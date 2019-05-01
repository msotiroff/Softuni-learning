namespace P03.DependencyInversion
{
    using Strategies;
    using System.Collections.Generic;

    public class PrimitiveCalculator
    {
        private IDictionary<char, ICalculatingStrategy> strategiesContainer;
        private ICalculatingStrategy calculatingStrategy;

        public PrimitiveCalculator()
        {
            this.InitializeAllStrategies();
            this.ChangeStrategy('+');
        }

        private void InitializeAllStrategies()
        {
            this.strategiesContainer = new Dictionary<char, ICalculatingStrategy>()
            {
                ['+'] = new AdditionStrategy(),
                ['-'] = new SubtractionStrategy(),
                ['*'] = new MultiplicationStrategy(),
                ['/'] = new DivisionStrategy(),
            };
        }

        public void ChangeStrategy(char @operator) 
            => this.calculatingStrategy = strategiesContainer[@operator];

        public int PerformCalculation(int firstOperand, int secondOperand) 
            => this.calculatingStrategy.Calculate(firstOperand, secondOperand);
    }
}
