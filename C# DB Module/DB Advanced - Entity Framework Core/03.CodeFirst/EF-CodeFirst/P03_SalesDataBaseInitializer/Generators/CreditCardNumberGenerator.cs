namespace P03_SalesDatabaseInitializer.Generators
{
    using System;

    public class CreditCardNumberGenerator
    {
        private static Random rnd = new Random();

        string number = NewNumber();

        public static string NewNumber()
        {
            int left = rnd.Next(100_000, 1_000_000);
            int right = rnd.Next(100_000, 1_000_000);

            return left.ToString() + right.ToString();
        }
    }
}
