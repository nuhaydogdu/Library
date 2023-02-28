using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Library.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("yazarlar");
            builder.Property(x => x.FirstName).HasColumnName("İsim");
            builder.Property(x => x.LastName).HasColumnName("Soyisim");
        }
    }
}
