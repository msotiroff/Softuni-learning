namespace P01_HospitalDatabase.Generators
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;

    public class DoctorsGenerator
    {
        private static Random rnd = new Random();

        public static Doctor NewDoctor(HospitalContext context)
        {
            string fullName = NameGenerator.FirstName() + " " + NameGenerator.LastName();

            string[] specialties = new string[]
                {
                    "General Practitioner",
                    "Orthopedic",
                    "Heart surgeon",
                    "Gynecologist",
                    "Dentist",
                    "Traumatologist",
                    "Neurologist",
                    "Virologist",
                    "Cardiologist",
                    "Allergologist",
                    "Sexologist",
                    "Pathologist",
                    "Psychoanalyst",
                    "Rheumatologist",
                    "Toxicologist"
                };

            var doctor = new Doctor()
            {
                Name = fullName,
                Specialty = specialties[rnd.Next(0, specialties.Length)]
            };

            return doctor;
        }
    }
}
