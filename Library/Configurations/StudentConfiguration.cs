using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Library.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasColumnType("varchar(30)");
            builder.Property(x => x.LastName).IsRequired();
            //birebir ilişkiyi kurmuş olduk
            builder.HasOne<StudentDetail>(s => s.StudentDetail)  //Student Model içerisindeki reletional property
                .WithOne(sd => sd.Student)                                              //StudentDetail içerisindeki relational property
                .HasForeignKey<StudentDetail>(sd => sd.StudentID);                      //StudentDetail içerisinde bulunan foreign key
        }
    }
}
