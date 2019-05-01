namespace SoftUniGameStore.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using SoftUniGameStore.Data;
    using SoftUniGameStore.Models;
    using SoftUniGameStore.Services.Models;

    public class UserService : IUserService
    {
        private readonly GameStoreDbContext db;

        public UserService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddToRole(string roleName, int userId)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var role = await this.db.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

            if (user == null || role == null)
            {
                return false;
            }

            try
            {
                var userRole = new UserRole
                {
                    UserId = userId,
                    RoleId = role.Id
                };

                await this.db.AddAsync(userRole);
                await this.db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserDetailsServiceModel>> All()
        {
            var allUsers = await this.db
                .Users
                .Select(u => new UserDetailsServiceModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = u.FullName,
                    IsAdmin = u.Roles.Any(ur => ur.Role.Name == "Administrator"),
                    IsModerator = u.Roles.Any(ur => ur.Role.Name == "Moderator")
                })
                .ToListAsync();

            return allUsers;
        }

        public async Task<int> Create(UserRegisterServiceModel model)
        {
            var user = new User
            {
                Email = model.Email,
                FullName = model.FullName,
                PasswordHash = model.PasswordHash,
            };

            var isFirstUserInDb = await this.db.Users.FirstOrDefaultAsync() == null;

            if (isFirstUserInDb)
            {
                var role = await this.db.Roles.FirstOrDefaultAsync();

                if (role != null)
                {
                    user.Roles.Add(new UserRole { Role = role });
                }
            }

            await this.db.Users.AddAsync(user);
            await this.db.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            var userWithMatchingEmail = await this.db.Users.FirstOrDefaultAsync(u => u.Email == email);

            return userWithMatchingEmail != null;
        }

        public async Task<int> TryLogin(UserLoginServiceModel model)
        {
            var loggedUserId = await this.db
                .Users
                .Where(u => u.Email == model.Email && u.PasswordHash == model.PasswordHash)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            return loggedUserId;
        }

        public async Task<bool> UserIsInRole(string roleName, int userId)
        {
            var role = await this.db
                .Roles
                .FirstOrDefaultAsync(r => r.Name == roleName);

            var isInRole = await this.db
                .UserRoles
                .FirstOrDefaultAsync(ur => ur.RoleId == role.Id && ur.UserId == userId) != null;

            return isInRole;
        }
    }
}
