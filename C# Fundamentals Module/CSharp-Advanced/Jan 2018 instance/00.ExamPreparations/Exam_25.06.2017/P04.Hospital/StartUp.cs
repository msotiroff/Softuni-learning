namespace P04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static readonly int maximumPatientsPerDepartment = 60;

        static void Main(string[] args)
        {
            var allDepartments = new Dictionary<string, List<string>>(); // => departments with their patients

            var allDoctors = new Dictionary<string, List<string>>(); // => doctors with their patients
            
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Output")
            {
                // Input format: {Department} {Doctor} {Patient}
                var inputParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var department = inputParams[0];
                var doctor = $"{inputParams[1]} {inputParams[2]}";
                var patient = inputParams[3];

                if (!allDepartments.ContainsKey(department))
                {
                    allDepartments[department] = new List<string>();
                }
                     
                if (allDepartments[department].Count < maximumPatientsPerDepartment)
                {
                    if (!allDoctors.ContainsKey(doctor))
                    {
                        allDoctors[doctor] = new List<string>();
                    }

                    allDepartments[department].Add(patient);
                    allDoctors[doctor].Add(patient);
                }
            }

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var commandParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandParams.Length == 1)
                {
                    allDepartments[commandParams.First()]
                            .ForEach(p => Console.WriteLine(p));
                }
                else
                {
                    if (char.IsDigit(inputLine.Last()))
                    {
                        var roomNumber = int.Parse(commandParams.Last());

                        var neededPatients = allDepartments[commandParams.First()]
                            .Skip((roomNumber - 1) * 3)
                            .Take(3)
                            .OrderBy(p => p)
                            .ToList();

                        neededPatients.ForEach(p => Console.WriteLine(p));
                    }
                    else
                    {
                        var doctor = $"{commandParams.First()} {commandParams.Last()}";
                        Console.WriteLine(string.Join(Environment.NewLine, allDoctors[doctor].OrderBy(p => p)));
                    }
                }
            }
        }
    }
}
