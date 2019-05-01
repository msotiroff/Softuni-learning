namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FastFood.Models.Enums;

    public class Order
    {
        /*
        Id – integer, Primary Key
        Customer – text (required)
        DateTime – date and time of the order (required)
        Type – OrderType enumeration with possible values: “ForHere, ToGo (default: ForHere)” (required)
        TotalPrice – decimal value (calculated property, (not mapped to database), required)
        EmployeeId – integer, foreign key
        Employee – The employee who will process the order (required) 
        OrderItems – collection of type OrderItem
         */

        [Key]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; } = OrderType.ForHere;

        [Required]
        public decimal TotalPrice { get; set; }

        public int EmployeeId { get; set; }
        [Required]
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        
    }
}