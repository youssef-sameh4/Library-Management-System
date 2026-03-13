
using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Data.Config
{
    internal class BorrowTransactionConfiguration : IEntityTypeConfiguration<BorrowTransaction>
    {
        public void Configure(EntityTypeBuilder<BorrowTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                   .HasMaxLength(50)
                   .IsRequired();

           
            
            builder.ToTable("BorrowTransactions");
        }
    }
}