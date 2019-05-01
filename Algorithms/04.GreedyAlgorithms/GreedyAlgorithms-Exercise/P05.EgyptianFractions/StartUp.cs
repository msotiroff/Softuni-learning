namespace P05.EgyptianFractions
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var fractionArgs = Console.ReadLine().Split('/');

            var nominator = int.Parse(fractionArgs[0]);
            var denominator = int.Parse(fractionArgs[1]);

            if (nominator >= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                Environment.Exit(0);
            }

            var builder = new StringBuilder($"{nominator}/{denominator} = ");

            if (denominator % nominator == 0)
            {
                denominator = denominator / nominator;
                nominator = 1;
                builder.Append($"1/{denominator}");
                Console.WriteLine(builder);
                Environment.Exit(0);
            }

            while (true)
            {
                int divider = (nominator + denominator) / nominator;
                builder.Append($"1/{divider} + ");

                nominator = (nominator * divider) - denominator;
                denominator = denominator * divider;

                if (denominator % nominator == 0)
                {
                    denominator = denominator / nominator;
                    nominator = 1;
                    builder.Append($"1/{denominator}");
                    break;
                }
            }

            var result = builder.ToString();

            Console.WriteLine(result);
        }
    }
}
