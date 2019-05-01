using System;

namespace ByTheCake.Services.Models
{
    public class UserProfileServiceModel
    {
        public string FullName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int OrdersCount { get; set; }
    }
}
