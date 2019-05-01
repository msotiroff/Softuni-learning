namespace SoftUniClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LecturerId { get; set; }

        public User Lecturer { get; set; }

        public IList<StudentCourse> Students { get; set; } = new List<StudentCourse>();
    }
}