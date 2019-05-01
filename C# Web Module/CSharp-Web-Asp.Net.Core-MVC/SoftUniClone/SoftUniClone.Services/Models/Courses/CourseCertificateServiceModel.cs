namespace SoftUniClone.Services.Models.Courses
{
    using AutoMapper;
    using SoftUniClone.Common.Mapping;
    using SoftUniClone.Models;
    using SoftUniClone.Models.Enums;
    using System;
    using System.Linq;

    public class CourseCertificateServiceModel : IAutoMapWith<Course>, ICustomMappingConfiguration
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Student { get; set; }

        public Grade Grade { get; set; }

        public string Lecturer { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string studentId = null;

            mapper
             .CreateMap<Course, CourseCertificateServiceModel>()
                .ForMember(dest => dest.Lecturer, opt => opt.MapFrom(src => src.Lecturer.Name))
            .ForMember(dest => dest.Student, opt => opt
                .MapFrom(src => src
                    .Students
                    .Where(s => s.StudentId == studentId)
                    .Select(s => s.Student.Name)
                    .FirstOrDefault()))
            .ForMember(dest => dest.Grade, opt => opt
                .MapFrom(src => src
                    .Students
                    .Where(s => s.StudentId == studentId)
                    .Select(s => s.Grade)
                    .FirstOrDefault()));
        }
    }
}