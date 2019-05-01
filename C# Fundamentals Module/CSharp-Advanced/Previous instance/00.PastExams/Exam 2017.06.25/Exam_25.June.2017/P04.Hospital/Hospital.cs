namespace P04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        private static readonly int maxPatientsPerDepartment = 60;

        public static void Main(string[] args)
        {
            // Department => List<Patent>
            var departments = new Dictionary<string, List<string>>();

            // Doctor => List<Patent>
            var doctors = new Dictionary<string, List<string>>();


            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Output")
            {
                // Inpit format: {Department} {Doctor} {Patient}

                var inputParams = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var currentDepartment = inputParams[0];
                var currentDoctor = inputParams[1] + " " + inputParams[2];
                var currentPatient = inputParams[3];

                if (!departments.ContainsKey(currentDepartment))
                {
                    departments[currentDepartment] = new List<string>();
                }

                if (departments[currentDepartment].Count < maxPatientsPerDepartment)
                {
                    departments[currentDepartment].Add(currentPatient);

                    if (!doctors.ContainsKey(currentDoctor))
                    {
                        doctors[currentDoctor] = new List<string>();
                    }
                    doctors[currentDoctor].Add(currentPatient);
                }
            }

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var inputParams = inputLine.Split();

                if (inputParams.Length == 1)
                {
                    var neededDepartment = inputParams[0];
                    // print all patients in this department in order of receiving on new line:
                    departments[neededDepartment].ForEach(p => Console.WriteLine(p));
                }
                else
                {
                    if (IsNumber(inputParams[1]))
                    {
                        var neededDepartment = inputParams[0];
                        var roomNumber = int.Parse(inputParams[1]);

                        var patients = departments[neededDepartment]
                            .Skip((roomNumber - 1) * 3)
                            .Take(3)
                            .OrderBy(p => p)
                            .ToList();

                        // print all patients in this room in alphabetical order each on new line
                        patients.ForEach(p => Console.WriteLine(p));
                    }
                    else
                    {
                        var doctor = inputParams[0] + " " + inputParams[1];
                        var patients = doctors[doctor].OrderBy(p => p).ToList();

                        // print all patients that are healed from doctor in alphabetical order on new line
                        patients.ForEach(p => Console.WriteLine(p));
                    }
                }
            }
        }

        private static bool IsNumber(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (!char.IsDigit(word[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}