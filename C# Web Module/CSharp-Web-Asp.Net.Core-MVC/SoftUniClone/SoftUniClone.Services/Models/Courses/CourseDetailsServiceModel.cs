namespace SoftUniClone.Services.Models.Courses
{
    using AutoMapper;
    using Common.Mapping;
    using SoftUniClone.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CourseDetailsServiceModel : IAutoMapWith<Course>, ICustomMappingConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Author { get; set; }

        public int Students { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
             .CreateMap<Course, CourseDetailsServiceModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Lecturer.Name))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students.Count));
        }
    }
}