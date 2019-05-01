namespace P01_StudentSystemDbInitializer.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;

    public class StudentGenetaror
    {
        internal static void InitialStudentSeed(StudentSystemContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                db.Students.Add(NewStudent());
                db.SaveChanges();
            }
        }

        public static Student NewStudent()
        {
            string name = NameGenerator.FirstName() + " " + NameGenerator.LastName();
            DateTime registeredOn = DateGenerator.GenerateDate();
            string phoneNumber = PhoneNumberGenerator.NewPhoneNumber();

            Student student = new Student()
            {
                Name = name,
                RegisteredOn = registeredOn,
                PhoneNumber = phoneNumber
            };

            return student;
        }
    }
}
