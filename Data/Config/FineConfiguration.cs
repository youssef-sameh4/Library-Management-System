using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryManagementSystem.Data.Config
{
    class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                   .HasColumnType("decimal(10,2)");

            builder.HasOne(x => x.BorrowTransaction)
                   .WithOne(x => x.Fine)
                   .HasForeignKey<Fine>(x => x.BorrowTransactionId);

            builder.ToTable("Fines");
        }
    }
}
