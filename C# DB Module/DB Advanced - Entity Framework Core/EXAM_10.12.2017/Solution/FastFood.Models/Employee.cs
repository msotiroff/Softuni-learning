namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
	{
        /*
        Id – integer, Primary Key
        Name – text with min length 3 and max length 30 (required)
        Age – integer in the range [15, 80] (required)
        PositionId ¬– integer, foreign key
        Position – the employee’s position (required)
        Orders – the orders the employee has processed
         */

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(15, 80)]
        public int Age { get; set; }
        
        public int PositionId { get; set; }
        [Required]
        public Position Position { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}