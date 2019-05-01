namespace SoftUniClone.Web.Areas.Admin.Models.Courses
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class CourseFormViewModel : IValidatableObject
    {
        [Required]
        [MaxLength(100, ErrorMessage = "The {0} must be less than {1} symbols long.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The {0} must be less than {1} symbols long.")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Lecturer")]
        public string LecturerId { get; set; }

        public IEnumerable<SelectListItem> Lecturers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date cannot be already passed.", new[] { nameof(this.StartDate) });
            }

            if (this.StartDate > this.EndDate)
            {
                yield return new ValidationResult("Start date should be before the End date.", new[] { nameof(this.StartDate) });
            }
        }
    }
}