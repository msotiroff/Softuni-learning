namespace SoftUniGameStore.App.Infrastructure.Extensions
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using SoftUniGameStore.Models;
    using System.Threading.Tasks;

    public static class DatabaseExtensions
    {
        public static GameStoreDbContext AddDefaultRoles(this GameStoreDbContext context)
        {
            Task
                .Run(async () =>
                {
                    var adminRole = await context
                        .Roles
                        .FirstOrDefaultAsync(r => r.Name == AppConstants.AdministratorRole);

                    if (adminRole == null)
                    {
                        await AddRole(context, AppConstants.AdministratorRole);
                    }

                    var modRole = await context
                       .Roles
                       .FirstOrDefaultAsync(r => r.Name == AppConstants.ModeratorRole);

                    if (modRole == null)
                    {
                        await AddRole(context, AppConstants.ModeratorRole);
                    }
                })
                .Wait();

            return context;
        }

        private static async Task AddRole(GameStoreDbContext context, string roleName)
        {
            var role = new Role
            {
                Name = roleName
            };

            await context.AddAsync(role);
            await context.SaveChangesAsync();
        }
    }
}
