namespace WizMail.App.Infrastructure.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WizMail.Data;
    using WizMail.Models;
    using WizMail.Models.Common;

    public static class DatabaseExtensions
    {
        public static WizMailDbContext SeedData(this WizMailDbContext context)
        {
            context.Database.Migrate();

            SeedFlags(context);

            return context;
        }

        private static void SeedFlags(WizMailDbContext context)
        {
            var flags = Enum.GetNames(typeof(ValidFlags));

            var unexistantFlags = new List<Flag>();

            foreach (var flag in flags)
            {
                var flagExist = context.Flags.Any(f => f.Name == flag);
                if (!flagExist)
                {
                    unexistantFlags.Add(new Flag { Name = flag });
                }
            }

            if (unexistantFlags.Any())
            {
                context.Flags.AddRange(unexistantFlags);
                context.SaveChanges();
            }
        }
    }
}
