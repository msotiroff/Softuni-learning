namespace ByTheCake.Services.Implementations
{
    using ByTheCake.Models;
    using ByTheCake.Services.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : DataAccessService, IUserService
    {
        private IHashService hashService;

        public UserService()
        {
            this.hashService = new HashService();
        }

        public async Task<int> Create(UserCreateServiceModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Username = model.Username,
                PasswordHash = this.hashService.ComputeHash(model.Password),
                RegistrationDate = model.RegistrationDate
            };

            await this.db.Users.AddAsync(user);
            await this.db.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> Exist(string userName)
            => await this.db
                .Users
                .FirstOrDefaultAsync(u => u.Username == userName) != null;

        public Task<UserProfileServiceModel> GetById(int userId)
            => this.db
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new UserProfileServiceModel
                {
                    FullName = u.Name,
                    RegistrationDate = u.RegistrationDate,
                    OrdersCount = u.Orders.Count
                })
                .FirstOrDefaultAsync();

        public async Task<int> TrySignIn(string username, string password)
        {
            var user = await this.db
                .Users
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == this.hashService.ComputeHash(password));

            return user != null ? user.Id : default(int);
        }
    }
}
