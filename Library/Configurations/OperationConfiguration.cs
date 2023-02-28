using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Library.Configurations
{
    //başta MyDbContext sınıfındaki OnModelCreating methodu içerisine yazdığımız fluent apileri daha düzgün olması için birer sınıf olarak bulunduracağız ilk olarak sınıfımızın  IEntityTypeConfiguration interfacesinden miras alması gerekiyor ve içerisine hangi modeleli referans kabul etmemiz gerektiğini yazacağız <Operation>
    //Operationla ilgili yapacağımız tüm configurationları artık Comfigure methodu içerisine yazacağız
    //En sonunda OperatingConfiguration sınıfının OnModelCreating methodu içerisinde çağırılması gerekiyor
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            //x bizim classımızın modelimizin içeriğini ifade ediyor
            //çok çok ilişkiyi ifade ederken öncelikle primary key belirlememiz gerekiyor devamında bire çok ilişkileri yazmamız gerekiyor 
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new { x.StudentID, x.BookID });
            builder.ToTable("operasyonlar");
            builder.Property(x => x.StartDate).IsRequired().HasColumnType("datetime");
            //bire çok ilişkiler
            builder.HasOne(o => o.Book).WithMany(b => b.Operations).HasForeignKey(o => o.BookID);
            builder.HasOne(o => o.Student).WithMany(s => s.Operations).HasForeignKey(o => o.StudentID);

        }
    }
}
