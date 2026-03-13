

using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Data.Config
{
    class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.PublisherName).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Country).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Website).HasColumnType("VARCHAR").HasMaxLength(200).IsRequired();
            builder.ToTable("Publishers");

        }
    }
}
