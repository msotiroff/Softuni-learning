namespace P03.DependencyInversion
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var calculator = new PrimitiveCalculator();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                var args = inputLine.Split();

                if (args[0] == "mode")
                {
                    var @operator = char.Parse(args[1]);
                    calculator.ChangeStrategy(@operator);
                }
                else
                {
                    var firstOperand = int.Parse(args[0]);
                    var secondOperand = int.Parse(args[1]);

                    var calculationResult = calculator.PerformCalculation(firstOperand, secondOperand);

                    Console.WriteLine(calculationResult);
                }
            }
        }
    }
}
