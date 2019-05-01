namespace P01_StudentSystemDbInitializer.Generators
{
    using System;

    public class DateGenerator
    {
        private static Random rnd = new Random();

        public static DateTime GenerateDate()
        {
            DateTime startDate = new DateTime(1970, 01, 01);
            DateTime endDate = new DateTime(2000, 12, 31);

            int daysDifference = (endDate - startDate).Days;

            // returns a date in range [startDate, endDate]:
            var date = startDate.AddDays(rnd.Next(0, daysDifference));

            return date;
        }

        public static DateTime GenerateEndDate(DateTime startDate)
        {
            
            var date = startDate.AddDays(rnd.Next(30, 60));

            return date;
        }
    }
}