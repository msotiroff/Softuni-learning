namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);

            builder.Ignore(ba => ba.PaymentMethodId);

            builder
                .Property(ba => ba.BankName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(ba => ba.SWIFTCode)
                .IsRequired(true)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
