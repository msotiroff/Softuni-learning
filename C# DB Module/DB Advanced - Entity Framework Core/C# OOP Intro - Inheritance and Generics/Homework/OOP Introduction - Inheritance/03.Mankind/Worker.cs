using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHours;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHours)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHours = workHours;
    }

    public decimal WorkHours
    {
        get { return workHours; }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHours = value;
        }
    }


    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public decimal GetSalaryPerHour()
    {
        decimal result = this.weekSalary / (5 * this.workHours);

        return result;
    }
}