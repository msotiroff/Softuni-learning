namespace SoftUniGameStore.Services.Models
{
    public class UserDetailsServiceModel
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string FullName { get; set; }
        
        public bool IsAdmin { get; set; }

        public bool IsModerator { get; set; }
    }
}
