namespace KittenShop.Data.Configurations
{
    using KittenShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KittenConfig : IEntityTypeConfiguration<Kitten>
    {
        public void Configure(EntityTypeBuilder<Kitten> builder)
        {
            builder
                .HasOne(k => k.Breed)
                .WithMany(b => b.Kittens)
                .HasForeignKey(k => k.BreedId);
        }
    }
}
