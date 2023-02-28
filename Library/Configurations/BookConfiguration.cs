using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Library.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //bire çok ilişki(foreign key yanlızca bir olan tarafta
            builder.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AutherID);
            builder.HasOne(b => b.BookType).WithMany(a => a.Books).HasForeignKey(b => b.BookTypeID);
        }
    }
}
