
using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Data.Config
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ISBN)
         .HasMaxLength(50)
         .IsRequired();
            builder.Property(x=>x.Title).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(1000);
            builder.Property(x => x.Language).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            builder.HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x=>x.BorrowTransactions).WithOne(x=>x.Book).HasForeignKey(x => x.BookId);

            builder.HasMany(x => x.Reviews)
       .WithOne(x => x.Book)
       .HasForeignKey(x => x.BookId);

            builder.HasMany(x => x.Reservations)
       .WithOne(x => x.Book)
       .HasForeignKey(x => x.BookId);

            builder.ToTable("Books");
        }
    }
}