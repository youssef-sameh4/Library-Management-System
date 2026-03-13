

using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Data.Config
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(500).IsRequired();
            builder.HasIndex(x => x.Email)
               .IsUnique();

            builder.HasMany(x=>x.BorrowTransactions).WithOne(x=>x.Member).HasForeignKey(x=>x.MemberId);

            builder.HasMany(x => x.Reservations)
               .WithOne(x => x.Member)
               .HasForeignKey(x => x.MemberId);

            // Member -> Reviews
            builder.HasMany(x => x.Reviews)
                   .WithOne(x => x.Member)
                   .HasForeignKey(x => x.MemberId);
            builder.ToTable("Members");

        }
    }
}
