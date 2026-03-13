using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Config
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Nationality).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Biography).HasColumnType("VARCHAR").HasMaxLength(1000).IsRequired();
            builder.ToTable("Authors");
        }
    }
}
