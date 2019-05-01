namespace P03.Mankind.Models
{
    using System;
    using System.Text;
    using static Common.Constants;

    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;

            private set
            {
                if (value < MinDailyWorkHours || value > MaxDailyWorkHours)
                {
                    throw new ArgumentException(string.Format(InvalidExpectedValueForWorker, nameof(workHoursPerDay)));
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;

            private set
            {
                if (value <= MinWeeklySalary)
                {
                    throw new ArgumentException(string.Format(InvalidExpectedValueForWorker, nameof(weekSalary)));
                }

                this.weekSalary = value;
            }
        }

        private decimal CalculateSalaryPerHour()
        {
            return this.weekSalary / (decimal)(this.workHoursPerDay * 5);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine($"Week Salary: {this.weekSalary:f2}");
            result.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            result.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

            return result.ToString().TrimEnd();
        }
    }
}
