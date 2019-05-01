namespace FDMC.Web.Infrastructure.Extensions
{
    using FDMC.Data;
    using FDMC.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDefaultBreeds(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FdmcDbContext>();

                context.Database.Migrate();

                var areBreedsSown = context.Breeds.Any();

                if (!areBreedsSown)
                {
                    var availableBreedsAsJson = File.ReadAllText(@"wwwroot\txt\Breeds.txt");

                    var breeds = JsonConvert.DeserializeObject<IEnumerable<Breed>>(availableBreedsAsJson);

                    context.Breeds.AddRange(breeds);
                    context.SaveChanges();
                }
            }

            return app;
        }
    }
}
