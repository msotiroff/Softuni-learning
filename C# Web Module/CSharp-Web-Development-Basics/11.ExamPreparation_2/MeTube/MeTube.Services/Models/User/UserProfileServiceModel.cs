namespace MeTube.Services.Models.User
{
    using MeTube.Models;
    using MeTube.Common.AutoMapping;
    using System.Collections.Generic;
    using MeTube.Services.Models.Tube;

    public class UserProfileServiceModel : IMapWith<User>
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public ICollection<TubeShortDetailsServiceModel> Tubes { get; set; }
    }
}
