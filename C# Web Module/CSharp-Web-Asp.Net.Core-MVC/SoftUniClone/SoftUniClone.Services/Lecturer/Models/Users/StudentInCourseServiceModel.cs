namespace SoftUniClone.Services.Lecturer.Models.Users
{
    using AutoMapper;
    using Common.Mapping;
    using SoftUniClone.Models;
    using SoftUniClone.Models.Enums;
    using System.Linq;

    public class StudentInCourseServiceModel : IAutoMapWith<User>, ICustomMappingConfiguration
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            int courseId = default(int);

            mapper
                .CreateMap<User, StudentInCourseServiceModel>()
                    .ForMember(dest => dest.Grade, opt => opt
                        .MapFrom(src => src.Courses
                            .Where(c => c.CourseId == courseId)
                            .Select(c => c.Grade)
                            .FirstOrDefault()));
        }
    }
}