namespace ModPanel.App.Infrastructure.Extensions
{
    using ModPanel.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ModPanel.Models.Common;
    using ModPanel.Models;

    public static class DatabaseExtensions
    {
        public static ModPanelDbContext SeedData(this ModPanelDbContext context)
        {
            context.Database.Migrate();

            SeedPositions(context);

            return context;
        }

        private static void SeedPositions(ModPanelDbContext context)
        {
            var availablePositions = Enum
                .GetNames(typeof(PositionType))
                .Select(p => p = p.Replace("_", " "));

            var positionsToSeed = new HashSet<Position>();

            foreach (var positionName in availablePositions)
            {
                if (!context.Positions.Any(p => p.Name == positionName))
                {
                    positionsToSeed.Add(new Position { Name = positionName });
                }
            }

            if (positionsToSeed.Any())
            {
                context.AddRange(positionsToSeed);
                context.SaveChanges();
            }
        }
    }
}
