namespace SoftUniClone.Services.Models.Users
{
    using AutoMapper;
    using Common.Mapping;
    using SoftUniClone.Models;
    using SoftUniClone.Models.Enums;
    using System.Linq;

    public class UserProfileCourseServiceModel : IAutoMapWith<Course>, ICustomMappingConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string studentId = null;

            mapper
                .CreateMap<Course, UserProfileCourseServiceModel>()
                    .ForMember(dest => dest.Grade, opt => opt
                        .MapFrom(src => src.Students
                            .Where(s => s.StudentId == studentId)
                            .Select(s => s.Grade)
                            .FirstOrDefault()));
        }
    }
}