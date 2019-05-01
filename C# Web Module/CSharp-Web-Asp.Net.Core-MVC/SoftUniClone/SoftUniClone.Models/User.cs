namespace SoftUniClone.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class User : IdentityUser
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IList<Course> Trainings { get; set; } = new List<Course>();

        public IList<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}