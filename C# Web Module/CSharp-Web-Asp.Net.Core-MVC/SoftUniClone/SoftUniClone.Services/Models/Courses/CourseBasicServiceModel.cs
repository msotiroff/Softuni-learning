namespace SoftUniClone.Services.Models.Courses
{
    using Common.Extensions;
    using Common.Mapping;
    using SoftUniClone.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class CourseBasicServiceModel : IAutoMapWith<Course>, ICustomMappingConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Resume { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
             .CreateMap<Course, CourseBasicServiceModel>()
                .ForMember(dest => dest.Resume, opt => opt.MapFrom(src => src.Description.ToResume()));
        }
    }
}