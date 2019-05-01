namespace Mankind.Models
{
    using System;
    using System.Text;
    using static Constants;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WorkHoursPerDay
        {
            get => this.workHoursPerDay;

            private set
            {
                if (value < MinDailyWorkHours || value > MaxDailyWorkHours)
                {
                    throw new ArgumentException(InvalidExpectedValueForWorker, nameof(workHoursPerDay));
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
                    throw new ArgumentException(InvalidExpectedValueForWorker, nameof(weekSalary));
                }

                this.weekSalary = value;
            }
        }

        public decimal CalculateSalaryPerHour()
        {
            return this.weekSalary / (this.workHoursPerDay * 5.0m);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine($"Week Salary: {this.weekSalary:f2}");
            result.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            result.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

            return result.ToString();
        }
    }
}
