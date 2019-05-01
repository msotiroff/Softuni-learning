using System;
class Startup
{
    static void Main(string[] args)
    {
        string[] studentParams = Console.ReadLine().Split();
        string[] workerParams = Console.ReadLine().Split();

        string studentFisrtName = studentParams[0];
        string studentLastName = studentParams[1];
        string studentFacultyNumber = studentParams[2];

        string workerFirstName = workerParams[0];
        string workerLastName = workerParams[1];
        decimal workerWeekSalary = decimal.Parse(workerParams[2]);
        decimal workerWorkHours = decimal.Parse(workerParams[3]);

        try
        {
            Student student = new Student(studentFisrtName, studentLastName, studentFacultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHours);

            Console.WriteLine($"First Name: {student.FirstName}");
            Console.WriteLine($"Last Name: {student.LastName}");
            Console.WriteLine($"Faculty number: {student.FacultyNumber}");
            Console.WriteLine();
            Console.WriteLine($"First Name: {worker.FirstName}");
            Console.WriteLine($"Last Name: {worker.LastName}");
            Console.WriteLine($"Week Salary: {worker.WeekSalary:f2}");
            Console.WriteLine($"Hours per day: {worker.WorkHours:f2}");
            Console.WriteLine($"Salary per hour: {worker.GetSalaryPerHour():f2}");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
