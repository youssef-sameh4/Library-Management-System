
using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Data.Config
{
    internal class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            builder.HasIndex(x => x.Email)
               .IsUnique();
            builder.Property(x => x.Role)
              .HasMaxLength(100);
            builder.HasMany(x => x.BorrowTransactions).WithOne(x=>x.Librarian).HasForeignKey(x=>x.LibrarianId).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.Reservations).WithOne(x => x.Librarian).HasForeignKey(x => x.LibrarianId).OnDelete(DeleteBehavior.Restrict);
            

            builder.ToTable("Librarians");
        }
    }
}
