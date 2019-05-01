namespace P01_StudentSystemDbInitializer.Generators
{
    using System;

    public class PhoneNumberGenerator
    {
        private static Random rnd = new Random();

        public static string NewPhoneNumber()
        {
            const string prepend = "+";

            var number = rnd.Next(100_000_000, 1_000_000_000);

            return prepend + number.ToString();
        }
    }
}