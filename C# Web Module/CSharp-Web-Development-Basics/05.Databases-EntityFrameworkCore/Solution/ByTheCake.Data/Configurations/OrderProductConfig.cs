namespace ByTheCake.Data.Configurations
{
    using ByTheCake.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderProductConfig : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder
                .HasOne(oa => oa.Order)
                    .WithMany(o => o.Products)
                    .HasForeignKey(oa => oa.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(oa => oa.Product)
                .WithMany(i => i.Orders)
                .HasForeignKey(oa => oa.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
